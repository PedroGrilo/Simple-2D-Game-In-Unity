using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_EE : MonoBehaviour
{

    public GameObject player;
    public GameObject target;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnCollisionEnter2D(Collision2D collision)
{
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = target.transform.position;
        }


    }
}
