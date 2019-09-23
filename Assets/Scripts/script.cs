using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{  
    public Transform target;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity, 0.05F);

        transform.position = new Vector3(posX,transform.position.y,transform.position.z);

    }
}