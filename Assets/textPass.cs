using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textPass : MonoBehaviour{
    private Text text;

    private static String moedas;

    private Text _text;

    // Start is called before the first frame update
    void Start(){
        _text = GetComponent<Text>();
        Debug.Log(moedas);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByBuildIndex(1).isLoaded){
            text = _text;
            text.text = moedas;
      
        }
    }
}
