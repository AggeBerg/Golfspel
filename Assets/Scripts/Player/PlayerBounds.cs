using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float playerMin = 1.7f;
    private Rigidbody BallSpeed;
    Vector3 PrePosition;
    Rigidbody someRigidbody;

    public void Start()
    {
        PrePosition = transform.position;
        BallSpeed = GetComponent<Rigidbody>();
    }


    public void setPrePosition()
    {
        PrePosition = transform.position;
        BallSpeed = GetComponent<Rigidbody>();
    }  

    public void Update()
    {
        
        if (transform.position.y < playerMin)
        {    
            transform.position = PrePosition;
            BallSpeed.velocity = new Vector3(0, 0, 0);
            UnityEngine.Debug.Log("Under allowed y-position");
        }        
    }
}
