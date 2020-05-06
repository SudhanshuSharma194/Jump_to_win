﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // We will move towards left [not moving the camera]
        // Only change in x-axis
        if (bird.IsAlive)
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}