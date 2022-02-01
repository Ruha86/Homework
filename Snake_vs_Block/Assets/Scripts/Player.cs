using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Transform> _tails = new List<Transform>();
    private float _boneDistance;
    public GameObject _bonePrefab;// ������ ���� ���� 

    public GameObject food;

    public GameState GameState; // ��������� ����
    public Transform SnakeHead; // ��������� ������ ����
    public TextMesh Text;

    private Vector3 _previousMousePosition; // ���������� ������� ����
    public float moveSpeed; // �������� �������� ������ ������
    public float Sensitivity; // ���������������� ����
    public float LeftBorder = -2.2f; // ����� �������
    public float RightBorder = 2.2f;    // ������ �������

    private int snakeHealth = 1; // �������� ������

    void Start()
    {
        Text.text = snakeHealth.ToString(); // ����������� ����� �������� (����� � ������)
    }

    void Update()
    {
        MoveHead();
        MoveTail();
    }

    // �������� ������ ����� �� ��� �
    private void MoveHead() 
    {
        // ���������� �������� ������
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        //��� ������� ������� ��� ��������� ������ � ����� �� ��� � 
        if (Input.GetMouseButton(0))
        {
            // ������� ����� � ������
            if (transform.position.x <= LeftBorder)
            {
                transform.position = new Vector3(LeftBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= RightBorder)
            {
                transform.position = new Vector3(RightBorder, transform.position.y, transform.position.z);
            }
            else 
            {
                Vector3 delta = Input.mousePosition - _previousMousePosition;
                transform.position = new Vector3(transform.position.x + delta.x * Sensitivity * Time.deltaTime, 
                    transform.position.y,
                    transform.position.z);
            }
        }
        _previousMousePosition = Input.mousePosition;
    }

    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_boneDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in _tails) 
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else 
            {
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider food)
    {
        if (food.TryGetComponent(out Food eat))
        {
            Destroy(food.gameObject);

            GameObject bone = Instantiate(_bonePrefab);
            _tails.Add(bone.transform);

        }
    }
}
