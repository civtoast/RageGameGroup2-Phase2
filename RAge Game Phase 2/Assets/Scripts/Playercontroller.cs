﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {
    public float walkspeed = 2;
    public float runspeed = 6;
    public float turnsmoothtime = 0.2f;
    public float jumpheight = 1;
    float turnsmoothvelocity;
    public float speedsmoothtime = 0.1f;
    float speedsmoothvelocity;
    float currentSpeed;
    Animator animator;
    public float gravity=-12;
    public Transform cameraT;
    float velocityY;
    float jumpTime = 0;
    public float jumpspeed = 0.5f;
    CharacterController controler;
    

    void Start () {
        animator = GetComponent<Animator>();
        controler = GetComponent<CharacterController> () ;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (inputDir != Vector2.zero)
        {
            float targetrotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,targetrotation,ref turnsmoothvelocity,turnsmoothtime);
        }
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetspeed = ((running) ? runspeed : walkspeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetspeed, ref speedsmoothvelocity, speedsmoothtime);
        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controler.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controler.velocity.x, controler.velocity.z).magnitude;
        if (controler.isGrounded)
        {
            velocityY = 0;
        }
        float animationSpeedPercent = ((running) ? currentSpeed/runspeed: currentSpeed/walkspeed*.5f);
        animator.SetFloat("Forward", animationSpeedPercent,speedsmoothtime,Time.deltaTime);
        
    }
    void Jump() {
        if (controler.isGrounded)
        {
            float jumpvelocity = Mathf.Sqrt(-2 * gravity * jumpheight);
            velocityY = jumpvelocity;
            
            
        }
        
       
    }
}
