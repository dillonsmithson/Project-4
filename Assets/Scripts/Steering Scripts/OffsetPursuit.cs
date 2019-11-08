using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 6.0f;
    public bool isEnabled = false;
    public float minDistance = 0.2f;

    private Vector3 targetVelocity = new Vector3(0.1f, 0.0f, 0.1f);
    

    // Update is called once per frame
    void Update()
    {
        if(isEnabled)
            PursueTarget();
    }

    void PursueTarget() {
        int T = 3;

        Vector3 pursueDir = (target.position - transform.position + targetVelocity) * T;
        float distance = pursueDir.magnitude;

        if(distance > minDistance) {
            Vector3 moveVector = pursueDir.normalized * moveSpeed * Time.deltaTime;

            transform.position += moveVector;
        }
    }
}
