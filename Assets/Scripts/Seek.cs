﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 6.0f;
    public bool isEnabled = false;

    private float minDistance = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(isEnabled)
            SeekTarget();
    }

    void SeekTarget() {
        // Subtracting two vectors by each will result in the desired direction
        Vector3 dir = target.position - transform.position;

        // Simple check to see if we continue seeking the target or if we are already at our desired distance from target
        if(dir.magnitude > minDistance) {
            Vector3 moveVector = dir.normalized * moveSpeed * Time.deltaTime;

            // If the case check is true, we continue moving towards our target.
            transform.position += moveVector;
        }
    }
}
