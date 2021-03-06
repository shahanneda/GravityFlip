﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //float lastUpdateTime = Time.del;
    public float speedH = 10.0f;
    public float speedV = 10.0f;
    public float jumpUpForce = 10.0f;
    public float jumpForwardForce = 10.0f;

    public float forwardForce = 0.01f;
    public float backwardsForce = 0.01f;
    public float rightForce = 0.01f;
    public float leftForce = 0.01f;

    public float maxForwardVelocity = 100f;

    private Rigidbody rigidbody;
    public float gyroTreshold = 0.1f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //-- For Joystick control -- 
        if(!CrossPlatformInputManager.GetAxis("Vertical").Equals(0)){
            rigidbody.AddForce(new Vector3(CrossPlatformInputManager.GetAxis("Vertical") * forwardForce, 0, 0), ForceMode.Force);
        }
        if (!CrossPlatformInputManager.GetAxis("Horizontal").Equals(0))
        {
            rigidbody.AddForce(new Vector3(0, 0, CrossPlatformInputManager.GetAxis("Horizontal") * -rightForce), ForceMode.Force);
        }
        // --  for default movement --
        if (rigidbody.velocity.x < maxForwardVelocity){
            rigidbody.AddForce(new Vector3(1 * forwardForce, 0, 0), ForceMode.Force);
        }

        // -- for testing on a computer
        if (Input.GetKey(KeyCode.W)){
            rigidbody.AddForce(new Vector3(1.0f *forwardForce, 0, 0), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S)){
            rigidbody.AddForce(new Vector3(-1.0f * backwardsForce, 0, 0), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D)){
            rigidbody.AddForce(new Vector3(0, 0, -1.0f * rightForce), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(new Vector3(0, 0, 1.0f * leftForce), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump")){
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.N))// TEMP
        {
            rigidbody.AddForce(new Vector3(1.0f * jumpForwardForce, 0, 0), ForceMode.Impulse);
        }

        //  gyroscope control
        if(Mathf.Abs(Input.acceleration.x  - gyroTreshold) > 0.1)
        {
            float direction = Input.acceleration.x > 0 ? 1 : -1;
            rigidbody.AddForce(new Vector3(0, 0, direction * 1* -rightForce), ForceMode.Force);
        }

        print(Input.acceleration.ToString());
    }

    void Jump(){
        rigidbody.AddForce(new Vector3(1.0f * jumpForwardForce, 1.0f * jumpUpForce, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLIDED WITH: " + collision.collider.name);
    }

}
