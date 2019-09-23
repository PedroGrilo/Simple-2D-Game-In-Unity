using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour 
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public bool collide;
    private float move = 0.5F;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(move,_rigidbody2D.velocity.y);   
        if(collide)
            flip();
    }
    
    private void flip()
    {
        move *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        collide = false;
    }
    
    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Plataformas"))
        {
            collide = true;
        }

        if (collision2D.gameObject.CompareTag("Player")){
            Debug.Log("atatck");
            _animator.SetBool("attack",true);
            move = 3F;
        }
    }
    public void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Plataformas"))
        {
            collide = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("fireball")){
            StartCoroutine(WaitForSeconds(0.05f));
        }
    }
    IEnumerator WaitForSeconds(float time){
        yield return new WaitForSecondsRealtime(time);
        Destroy(transform.gameObject);
       
    }

}
