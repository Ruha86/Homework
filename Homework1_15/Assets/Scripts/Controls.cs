using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Level;
    public float sensitivity;

    private Vector3 _previousMousePos;

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 delta = Input.mousePosition - _previousMousePos;
            Level.Rotate(0, -delta.x * sensitivity, 0);
        }

        _previousMousePos = Input.mousePosition;
        
    }
}
