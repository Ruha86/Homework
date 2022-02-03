using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameState GameState; // ��������� ����
    public Transform SnakeHead; // ��������� ������ ����
    public TextMesh Text;

    private SnakeTail snakeTail;
    public Rigidbody snakeBodyRB;

    private Vector3 _previousMousePosition; // ���������� ������� ����
    public float moveSpeed; // �������� �������� ������ ������
    public float Sensitivity; // ���������������� ����
    private float LeftBorder = -2.3f; // ����� �������
    private float RightBorder = 2.3f;    // ������ �������

    private List<Transform> BodyParts = new List<Transform>();

    private int foodValue; // �������� ���
    private int blockValue; // �������� ������

    [SerializeField]
    private int StartLength = 5;
    [SerializeField]
    private int snakeHealth; // �������� ������
    [SerializeField]
    private int snakeLength = 0;  // ����� ������


    void Start()
    {
        snakeBodyRB = GetComponent<Rigidbody>();
        snakeTail = GetComponent<SnakeTail>();
        Text.text = snakeHealth.ToString(); // ����������� ����� �������� (����� � ������)

        IncreaseSnake(StartLength);
        Debug.Log($"Health = {snakeHealth}, Length = {snakeLength}");
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
        // ������������ � ����
        if (collision.gameObject.tag == "Food")
        {
            foodValue = collision.gameObject.GetComponent<Food>().Value;
            // snakeHealth += foodValue;
            // Text.text = snakeHealth.ToString();
            Destroy(collision.gameObject);
            IncreaseSnake(foodValue);
            Debug.Log($"FOOD value = {foodValue}: Health = {snakeHealth}, Length = {snakeLength}");
        }

        // ������������ � ������
        if (collision.gameObject.tag == "Block")
        {
            blockValue = collision.gameObject.GetComponent<Block>().Value;

            if (snakeHealth > blockValue)
            {
                Destroy(collision.gameObject);
                //snakeHealth -= blockValue;
                DecreaseSnake(blockValue);
                Debug.Log($"BLOCK value = {blockValue}: Health = {snakeHealth}, Length = {snakeLength}");
            }

            if (snakeHealth <= blockValue)
            {
                GameState.OnPlayerDead();
                snakeBodyRB.velocity = Vector3.zero;
                Debug.Log($"BLOCK: Snake Dead");
            }
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            GameState.OnPlayerWin();
        }
    }

    private void IncreaseSnake(int Value) 
    {
        for (int i = 0; i < Value; i++) 
        {
            snakeLength++;
            snakeHealth++;
            snakeTail.AddBody();
            Text.text = snakeHealth.ToString();
        }
    }

    private void DecreaseSnake(int Value) 
    {
        for (int i = 0; i < Value; i++)
        {
            snakeLength--;
            snakeHealth--;
            snakeTail.RemoveBody();
            Text.text = snakeHealth.ToString();
        }
    }
}
