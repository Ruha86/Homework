using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameState GameState; // holding game state
    public Transform snakeHead; // transform of snake head
    public TextMesh text;

    public int value; // переменная для поглощения balls
    public int snakeHealth = 1; // count of balls
    public int snakeLength = 1; // count of balls
    private SnakeTail _snakeTail; // tail of the snake

    private Vector3 _previousMousePosition;
    public float moveSpeed;
    public float Sensitivity;
    public float LeftBorder = -2.2f;
    public float RightBorder = 2.2f;



    // Start is called before the first frame update
    void Start()
    {
        text.text = snakeHealth.ToString();
        _snakeTail = GetComponent<SnakeTail>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        
        if (Input.GetMouseButton(0)) 
        {
            if (transform.position.x <= LeftBorder)
            {
                transform.position = new Vector3(LeftBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= RightBorder)
            {
                transform.position = new Vector3(RightBorder, transform.position.y, transform.position.z);
            }
            else { mouseMover(); }
        }
        _previousMousePosition = Input.mousePosition;
    }

    private void mouseMover() 
    {
        Vector3 delta = Input.mousePosition - _previousMousePosition;
        transform.position = new Vector3(transform.position.x + delta.x * Sensitivity * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
