using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float velocity;

    private bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update(){
        if (transform.position.x > end.position.x )
            moveRight = false;

        if (transform.position.x < start.position.x)
            moveRight = true;
        
        if(moveRight)
            transform.position = new Vector2(transform.position.x + 2f * Time.deltaTime,transform.position.y);
        else{
            transform.position = new Vector2(transform.position.x - 2f * Time.deltaTime,transform.position.y);
        }
    }
}
