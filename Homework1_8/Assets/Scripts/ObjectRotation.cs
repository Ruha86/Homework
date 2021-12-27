using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public GameObject[] gameObjects = new GameObject[4];

    public Vector3[] rotationSpeeds = new Vector3[4];

    void Update()
    {
        foreach (GameObject gameObject in gameObjects) 
        {
            RotateObject();
        }
    }

    private void RotateObject() 
    {
        for (int i = 0 ; i < gameObjects.Length; i++) 
        {
            for (i = 0; i < rotationSpeeds.Length; i++)
            {
                gameObjects[i].transform.Rotate(rotationSpeeds[i] * Time.deltaTime);
            }
        }
    }
}
