using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    private AvoidanceDetector avoidanceDetector;
    private CohesionDetector cohesionDetector;

    private void Awake()
    {
        avoidanceDetector = GetComponentInChildren<AvoidanceDetector>();
        cohesionDetector = GetComponentInChildren<CohesionDetector>();
    }
}
