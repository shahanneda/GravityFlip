using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //float lastUpdateTime = Time.del;
    public float speedH = 10.0f;
    public float speedV = 10.0f;
    public float jumpUpForce = 10.0f;
    public float jumpForwardForce = 10.0f;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector3(1 * speedV * Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(new Vector3(-1 * speedV * Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(new Vector3(0, 0, -1 * speedH * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 1 * speedH * Time.deltaTime));
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    void Jump(){
        rigidbody.AddForce(new Vector3(1.0f * jumpForwardForce, 1.0f * jumpUpForce, 0), ForceMode.Impulse);
    }

}
