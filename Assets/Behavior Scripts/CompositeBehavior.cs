using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public List<FlockBehavior> behaviors;
    private List<float> weights;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (weights.Count == 0)
            FillWeights();

        //handle data mismatch
        if (weights.Count != behaviors.Count)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }

        //set up move
        Vector2 move = Vector2.zero;

        //iterate through behaviors
        for (int i = 0; i < behaviors.Count; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;

            }
        }

        return move;


    }

    private void FillWeights()
    {
        weights = new List<float>();
        weights.Add(UIDataAccessor.Instance.GetFlockingForceData().weight);
        weights.Add(UIDataAccessor.Instance.GetCollisionAvoidanceData().weight);
        weights.Add(UIDataAccessor.Instance.GetGroupingForceData().weight);
        weights.Add(UIDataAccessor.Instance.GetObstacleAvoidanceData().weight);
    }
}
