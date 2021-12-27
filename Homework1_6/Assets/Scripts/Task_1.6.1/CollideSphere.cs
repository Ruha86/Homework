using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSphere : MonoBehaviour
{
    public Rigidbody Sphere;
    public Vector3 Force;

    private void Start()
    {
        Sphere.AddForce(Force, ForceMode.Impulse);
    }
}
