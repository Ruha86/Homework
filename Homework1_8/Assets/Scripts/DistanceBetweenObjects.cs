using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBetweenObjects : MonoBehaviour
{
    public Transform Object1;
    public Transform Object2;
    private double distance;

    void Update()
    {
        Distance();
        
    }

    private void Distance() 
    {
        distance = Math.Sqrt(
                Math.Pow(Object1.position.x - Object2.position.x,2)
            + Math.Pow(Object1.position.y - Object2.position.y,2)
            + Math.Pow(Object1.position.z - Object2.position.z,2)
            );
        Debug.Log(distance);
    }
}
