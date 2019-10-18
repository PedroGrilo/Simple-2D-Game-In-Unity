using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragon : MonoBehaviour { 

    public Transform start;
    public Transform end;
    public float velocity;
    private SpriteRenderer _spriteRenderer;
    public GameObject fireball;
    public Transform target;
    private Transform originalPos;

    private bool moveRight = true;

// Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        originalPos = this.GetComponent<Transform>();
    }

    
    // Update is called once per frame
    void Update(){
        Movement();
        Shoot();
    }
    
    void Movement()
    {

        if (transform.position.x > end.position.x)
            moveRight = false;

        if (transform.position.x < start.position.x)
            moveRight = true;

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + velocity * Time.deltaTime, transform.position.y);
            _spriteRenderer.flipX = true;
        }
        else
        {

            _spriteRenderer.flipX = false;
            transform.position = new Vector2(transform.position.x - velocity * Time.deltaTime, transform.position.y);
        }

    }
    void Shoot()

    {
        GameObject fireball = Instantiate(fireball, transform.position.x,transform.position.y);

    }
}
