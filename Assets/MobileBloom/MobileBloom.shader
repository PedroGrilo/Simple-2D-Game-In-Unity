Shader "SupGames/Mobile/Bloom"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "" {}
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	struct v2f {
		half4 pos : POSITION;
		half2 uv  : TEXCOORD0;
	};

	struct v2fb
	{
		half4 pos  : SV_POSITION;
		half4  uv  : TEXCOORD0;
	};

	sampler2D _MainTex;
	sampler2D _BloomTex;
	uniform half4 _MainTex_TexelSize;
	uniform half _BloomAmount;
	uniform half _BlurAmount;
	uniform half _FadeAmount;

	v2fb vertb(appdata_img v)
	{
		v2fb o;
		o.pos = UnityObjectToClipPos(v.vertex);
		half2 uv = v.texcoord.xy;
		half2 offset = (_MainTex_TexelSize.xy) * _BlurAmount;
		o.uv = half4(uv - offset, uv + offset);
		return o;
	}
	v2f vert(appdata_img v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}
	fixed4 fragMain(v2fb i) : COLOR
	{
		fixed4 result = tex2D(_MainTex, i.uv.xy);
		result += tex2D(_MainTex, i.uv.xw);
		result += tex2D(_MainTex, i.uv.zy);
		result += tex2D(_MainTex, i.uv.zw);
		return max(result*0.25h-_FadeAmount,0.0h);
	}
	fixed4 fragBloom(v2fb i) : COLOR
	{
		fixed4 result = tex2D(_MainTex, i.uv.xy);
		result += tex2D(_MainTex, i.uv.xw);
		result += tex2D(_MainTex, i.uv.zy);
		result += tex2D(_MainTex, i.uv.zw);
		return result*0.25h;
	}

	fixed4 frag(v2f i) : COLOR
	{
		fixed4 c = tex2D(_MainTex, i.uv);
		fixed4 b = tex2D(_BloomTex, i.uv)*_BloomAmount;
		return (c+b)*0.5h;
	}
	ENDCG 
		
	Subshader 
	{
		ZTest Always Cull Off ZWrite Off
		Fog{ Mode off }

		Pass
		{
		  CGPROGRAM
		  #pragma vertex vertb
		  #pragma fragment fragMain
		  #pragma fragmentoption ARB_precision_hint_fastest
		  ENDCG
		}
		ZTest Always Cull Off ZWrite Off
		Fog{ Mode off }

		Pass
		{
		  CGPROGRAM
		  #pragma vertex vertb
		  #pragma fragment fragBloom
		  #pragma fragmentoption ARB_precision_hint_fastest
		  ENDCG
		}
		Pass
		{
		  CGPROGRAM
		  #pragma vertex vert
		  #pragma fragment frag
		  #pragma fragmentoption ARB_precision_hint_fastest
		  ENDCG
		}
	}
	Fallback off
	}