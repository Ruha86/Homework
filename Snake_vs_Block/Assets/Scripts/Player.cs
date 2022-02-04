using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public GameState GameState; // состояние игры
    public Transform SnakeHead; // трансформ головы змеи
    public TextMesh Health;

    private SnakeTail snakeTail;
    public Rigidbody snakeBodyRB;

    private Vector3 _previousMousePosition; // предыдущаа позиция мыши
    public float moveSpeed; // скорость движения змейки вперед
    public float Sensitivity; // чувствительность мыши
    private float LeftBorder = -2.3f; // левая граница
    private float RightBorder = 2.3f;    // правая граница

    private List<Transform> BodyParts = new List<Transform>();

    private int foodValue; // ценность еды
    private int blockValue; // ценность блоков
    
    [SerializeField]
    public int snakeHealth = 4; // здоровье змейки
    [SerializeField]
    public int snakeLength = 1;  // длина змейки

    public int foodCounter = 0;


    void Start()
    {
        snakeBodyRB = GetComponent<Rigidbody>();
        snakeTail = GetComponent<SnakeTail>();
        Health.text = snakeHealth.ToString(); // отображение числа здоровья (шаров в змейке)
        IncreaseSnake(snakeHealth);
        Debug.Log($"Health = {snakeHealth}, Length = {snakeLength}");
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
        // Столкновение с едой
        if (collision.gameObject.tag == "Food")
        {
            foodValue = collision.gameObject.GetComponent<Food>().Value;

            foodCounter += foodValue;
            snakeHealth += foodValue; // прибавим значение к здоровью
            Health.text = snakeHealth.ToString();

            Destroy(collision.gameObject);
            IncreaseSnake(foodValue);

            Debug.Log($"FOOD value = {foodValue}: Health = {snakeHealth}, Length = {snakeLength}");
        }

        // Столкновение с блоком
        if (collision.gameObject.tag == "Block")
        {
            blockValue = collision.gameObject.GetComponent<Block>().Value;

            Debug.Log($"BLOCK value = {blockValue}");
            Debug.Log($"Health current = {snakeHealth}, Length current = {snakeLength}");

            if (snakeHealth > blockValue)
            {
                snakeHealth -= blockValue;
                Destroy(collision.gameObject);
                DecreaseSnake(blockValue);
                Health.text = snakeHealth.ToString();
                Debug.Log($"Health remained = {snakeHealth}, Length remained = {snakeLength}");
            }
            if (snakeHealth < 0)
            {
                GameState.OnPlayerDead();
                snakeBodyRB.velocity = Vector3.zero;
            }
        }
    }

    public void IncreaseSnake(int Value) 
    {
        for (int i = 0; i < Value; i++) 
        {
            snakeLength++;
            snakeTail.AddBody();
        }
    }

    public void DecreaseSnake(int Value) 
    {
        for (int i = 0; i < Value; i++)
        {
            snakeLength--;
            snakeTail.RemoveBody();
        }
    }
}
