using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                gameObject.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
        }

        if (Input.GetKey(KeyCode.D)) 
            transform.position = new Vector3(gameObject.transform.position.x + moveSpeed, 0.5f, transform.position.z);
        if(Input.GetKey(KeyCode.A))
            transform.position = new Vector3(gameObject.transform.position.x - moveSpeed, 0.5f, transform.position.z);
        if(Input.GetKey(KeyCode.S))
            transform.position = new Vector3(gameObject.transform.position.x, 0.5f, transform.position.z - moveSpeed);
        if (Input.GetKey(KeyCode.W))
            transform.position = new Vector3(gameObject.transform.position.x, 0.5f, transform.position.z + moveSpeed);
    }
}
