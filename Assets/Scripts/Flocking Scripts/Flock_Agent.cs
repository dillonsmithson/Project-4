using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Flock_Agent : MonoBehaviour {
    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start() {
        agentCollider = GetComponent<Collider>();
    }

    public void Move(Vector3 Velocity) {
        transform.forward = Velocity;
        transform.position += Velocity * Time.deltaTime;
    }
}
