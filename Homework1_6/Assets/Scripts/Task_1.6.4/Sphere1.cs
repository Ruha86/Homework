using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere1 : MonoBehaviour
{
    public Rigidbody Sphere;
    public Vector3 Force;

    void Update()
    {
        Sphere.AddForce(Force, ForceMode.Force);
    }
}
