using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContol : MonoBehaviour
{
    public Transform target; // ���� ������ ������� ������� ������
    public Transform Camera;
    private float cameraXAngle = 25f;
    private Vector3 offset = new Vector3(0, 1.8f, -4f);  // ������ ������ �� ����
    public float sensitivity = 3; // ���������������� �����
    private float X;

    void Start()
    {
        transform.position = target.position + offset;
    }

    void Update()
    {
        OrbitRotate();
    }

    private void OrbitRotate()
    {
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(cameraXAngle, X, 0);
        transform.position = transform.localRotation * offset + target.position;
    }
}
