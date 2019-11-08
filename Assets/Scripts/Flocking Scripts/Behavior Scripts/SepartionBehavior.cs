using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Separation")]
public class SepartionBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock) {
        // If no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        // Add all points together and average
        Vector3 separationMove = Vector3.zero;
        int nSeparate = 0;
        foreach (Transform item in context) {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SqaureSeparationRadius) {
                nSeparate++;
                separationMove += agent.transform.position - item.position;
            }
        }

        if (nSeparate > 0)
            separationMove /= nSeparate;
        return separationMove;
    }
}
