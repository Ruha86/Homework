using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    public Vector3 RotationSpeedOx = new Vector3(50f,0f,0f);
    public Vector3 RotationSpeedOy = new Vector3(0f, 70f, 0f);
    public Vector3 RotationSpeedOz = new Vector3(0f, 0f, 80f);
    public Vector3 RotationSpeedOxOyOz = new Vector3(60f, 60f, 60f);


    void Update()
    {
        object1.transform.Rotate(RotationSpeedOx * Time.deltaTime);
        object2.transform.Rotate(RotationSpeedOy * Time.deltaTime);
        object3.transform.Rotate(RotationSpeedOz * Time.deltaTime);
        object4.transform.Rotate(RotationSpeedOxOyOz * Time.deltaTime);
    }
}
