using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAddition : MonoBehaviour
{
    public Transform Object1;
    public Transform Object2;
    private Vector3 start = new Vector3(0, 0, 0);

    void Update()
    {
        transform.position = Object1.position + Object2.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(start, Object1.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(start, Object2.position);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(start, Object1.position + Object2.position);
    }

}
