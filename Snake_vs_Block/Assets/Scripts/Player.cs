using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameState GameState; // ��������� ����
    public Transform SnakeHead; // ��������� ������ ����
    public TextMesh Text;

    private SnakeTail snakeTail;
    public Rigidbody snakeRB;

    private Vector3 _previousMousePosition; // ���������� ������� ����
    public float moveSpeed; // �������� �������� ������ ������
    public float Sensitivity; // ���������������� ����
    private float LeftBorder = -2.3f; // ����� �������
    private float RightBorder = 2.3f;    // ������ �������

    private List<Transform> BodyParts = new List<Transform>();

    private int value = 1;
    public int Length = 1;

    public int snakeHealth = 1; // �������� ������
    

    void Start()
    {
        snakeRB = GetComponent<Rigidbody>();
        snakeTail = GetComponent<SnakeTail>();
        Text.text = snakeHealth.ToString(); // ����������� ����� �������� (����� � ������)
    }

    void Update()
    {
        MoveHead();
    }

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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            value = collision.gameObject.GetComponent<Food>().Value;
            snakeHealth += value;
            Text.text = snakeHealth.ToString();
            Destroy(collision.gameObject);

            for (int i = 0; i < value; i++)
            {
                Length ++;
                snakeTail.AddBody();
            }
        }
        else if (collision.gameObject.tag == "Block")
        {
            value = collision.gameObject.GetComponent<Block>().Value;

            // !!!! ���������� ������� ��������� ���� �� 0, ���� 0 �� �������
            if (value >= snakeHealth)   
            {
                GameState.OnPlayerDead();
                snakeRB.velocity = Vector3.zero;
            }
            else
            {
                snakeHealth -= value;
                Text.text = snakeHealth.ToString();
                Destroy(collision.gameObject);

                for (int i = 0; i < value; i++)
                {
                    Length--;
                    snakeTail.RemoveBody();
                }
                
            }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            GameState.OnPlayerWin();
        }
    }
}
