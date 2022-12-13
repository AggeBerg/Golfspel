using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float playerMin = 2.0f;
    Vector3 PrePosition;
    Rigidbody someRigidbody;

    public void Start()
    {
        PrePosition = transform.position;
        Debug.Log(PrePosition);
        BallSpeed = GetComponent<Rigidbody>();
    }


    public void setPrePosition()
    {
        PrePosition = transform.position;
        Debug.Log(PrePosition);
        BallSpeed = GetComponent<Rigidbody>();
    }  

    public void Update()
    {
        
        if (transform.position.y < playerMin)
        {    
            transform.position = PrePosition;
            Debug.Log(transform.position);
            BallSpeed.velocity = new Vector3(0, 0, 0);
        }        
    }
}
