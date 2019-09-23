using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour{
    private bool touched = true;
    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){ }


    private void OnCollisionEnter2D(Collision2D other){

    }

    private void OnTriggerStay2D(Collider2D other){
    
        if (other.gameObject.CompareTag("Plataformas") || other.gameObject.CompareTag("Animal")){
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().SetBool("boom",true);
            StartCoroutine(WaitForSeconds(0.39F));
        }
    }


    IEnumerator WaitForSeconds(float time){
        yield return new WaitForSecondsRealtime(time);
         Destroy(transform.gameObject);
       
    }
}