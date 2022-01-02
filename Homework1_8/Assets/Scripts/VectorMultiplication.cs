using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMultiplication : MonoBehaviour
{
    public Transform Object1;
    public float number;
    private Vector3 start = new Vector3(0, 0, 0);

    void Update()
    {
        transform.position = Object1.position * number;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(start, Object1.position);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(start, Object1.position * number);
    }
}
