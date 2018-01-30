﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    float jumpSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator ani;
    private Player player;
    private bool PlayerStop;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        PlayerStop = true;
    }
	
	// Update is called once per frame
	void Update () {
        //----------------------------------------RunRight------------------------------------
        if(PlayerStop)
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        //TODO Add run animation

        //----------------------------------------Jump------------------------------------
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && gameObject.transform.position.y < 0 && PlayerStop ||
            Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.y < 0 && PlayerStop) //Space and A to jump.
        {
            //TODO Add jump animation
            print("jump");
            rigidbody2D.AddForce(Vector2.up * jumpSpeed);
        }

        //----------------------------------------Duck------------------------------------
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && gameObject.transform.position.y < 0 && PlayerStop ||
            Input.GetKeyDown(KeyCode.LeftShift) && gameObject.transform.position.y < 0 && PlayerStop) //LeftShift and B to duck.
        {
            print("duck");
            //TODO Add duck animation            
        }
    }
    public void SetPlayerStartStop()
    {
        PlayerStop =! PlayerStop;
    }
}
