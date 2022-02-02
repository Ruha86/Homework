using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameState GameState; // состояние игры
    public Transform SnakeHead; // трансформ головы змеи
    public TextMesh Text;

    private SnakeTail snakeTail;
    public Rigidbody snakeRB;

    private Vector3 _previousMousePosition; // предыдущаа позиция мыши
    public float moveSpeed; // скорость движения змейки вперед
    public float Sensitivity; // чувствительность мыши
    private float LeftBorder = -2.3f; // левая граница
    private float RightBorder = 2.3f;    // правая граница

    private List<Transform> BodyParts = new List<Transform>();

    private int value = 1;
    public int Length = 1;

    public int snakeHealth = 1; // здоровье змейки
    

    void Start()
    {
        snakeRB = GetComponent<Rigidbody>();
        snakeTail = GetComponent<SnakeTail>();
        Text.text = snakeHealth.ToString(); // отображение числа здоровья (шаров в змейке)
    }

    void Update()
    {
        MoveHead();
    }

    private void MoveHead()
    {
        // постоянное движение вперед
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        //при зажатой клавише ЛКМ двигается вправа и влево по оси Х 
        if (Input.GetMouseButton(0))
        {
            // границы слева и справа
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

            // !!!! переписать пласное отнимание тела до 0, если 0 то смекрть
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
