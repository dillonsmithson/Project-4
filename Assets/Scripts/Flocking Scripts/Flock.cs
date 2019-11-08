using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Flock_Agent agentPrefab;
    List<Flock_Agent> agents = new List<Flock_Agent>();
    public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 250;
    const float agentDesity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float separationRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareSeparationRadius;
    public float SqaureSeparationRadius { get { return squareSeparationRadius; } }


    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareSeparationRadius = squareNeighborRadius * separationRadiusMultiplier * separationRadiusMultiplier;

        for(int i=0; i<startingCount; i++) {
            Flock_Agent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * startingCount * agentDesity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
            newAgent.GetComponentInChildren<Renderer>().material.color = Random.ColorHSV(0.5f, 0.6f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Flock_Agent agent in agents) {
            List<Transform> context = GetNearbyObjects(agent);

            // DEBUG ONLY
            

            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
                move = move.normalized * maxSpeed;
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(Flock_Agent agent) {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach(Collider c in contextColliders) {
            if(c != agent.AgentCollider)
                context.Add(c.transform);
        }
        return context;
    }
}
