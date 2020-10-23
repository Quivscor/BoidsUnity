using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionDetector : MonoBehaviour
{
    private SphereCollider col;

    [SerializeField]
    private float _radius;
    public float Radius { get => _radius; private set { _radius = value; } }

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
