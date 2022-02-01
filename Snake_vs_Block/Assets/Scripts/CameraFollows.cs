using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public GameObject Player;
    public Transform Camera;
    
    public float camera_YOffset;
    public float camera_ZOffset;

    private float xAngle;

    // Start is called before the first frame update
    void Start()
    {
        Camera.Rotate(xAngle, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(0.0f,
            Player.transform.position.y + camera_YOffset,
            Player.transform.position.z + camera_ZOffset);
    }
}
