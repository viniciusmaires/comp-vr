﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes objects float up & down while gently spinning.
public class Robo : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 0.5f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
