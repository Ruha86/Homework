using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Animator animator;
    private int _state;
    
    public GameObject Player;
    public float sensitivity = 3; // ���������������� �����
    private float X;
    private float WalkSpeed = 2;

    private void Start()
    {
        animator = GetComponent<Animator>(); // ��������� ���������� �������� ������� �� �������� ��������� � ���������
    }

    private void Update()
    {
        ObjectRotate();
        Idle();
        WalkForward();
        WalkBackward();
        StrafeRight();
        StrafeLeft();
        
        animator.SetInteger("State", _state); // ���������� �������� ���������� _state � ��������
    }

    private void ObjectRotate() 
    {
        
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(0, X, 0);
    }

    private void Idle()
    {
        _state = 0;
    }

    private void WalkForward()
    {
        if (Input.GetKey(KeyCode.W)) // ���� W ��� ���� ��� �� ����
        {
            if (Input.GetKey(KeyCode.LeftShift)) // run
            {
                _state = 2; // ���� ���� W + ���� �� �����
                transform.position += transform.forward * WalkSpeed * 2 * Time.deltaTime;
                Debug.Log("Run");
                Debug.Log("State = " + _state);
            }
            else // walk
            {
                _state = 1; // ���� ���� W �� ������ ����
                transform.position += transform.forward * WalkSpeed * Time.deltaTime;
                Debug.Log("Walk");
                Debug.Log("State = " + _state);
            }
        }
        
    }

    private void WalkBackward()
    {
        if (Input.GetKey(KeyCode.S)) // ���� S ��� ���� ��� �� ����
        {
            _state = 5; // ���� ���� S �� ������ ����
            transform.position -= transform.forward * WalkSpeed * Time.deltaTime;
            Debug.Log("WalkBack");
            Debug.Log("State = " + _state);
        }

    }

    private void StrafeLeft()
    {
        if (Input.GetKey(KeyCode.A)) // ���� ���� A - �� ������ �����
        {
            if (Input.GetKey(KeyCode.W)) 
            {
                _state = 6;
                transform.position += transform.forward * WalkSpeed * 0.5f * Time.deltaTime;
                transform.position += -transform.right * WalkSpeed * 0.5f * Time.deltaTime;
            }
            else 
            {
                _state = 3;
                transform.position += -transform.right * WalkSpeed * Time.deltaTime;
                Debug.Log("Strafe left");
                Debug.Log("State = " + _state);
            }
            
        }
        
    }

    private void StrafeRight()
    {
        if (Input.GetKey(KeyCode.D)) // ���� ���� D - �� ������ ������
        {
            if (Input.GetKey(KeyCode.W))
            {
                _state = 7;
                transform.position += transform.forward * WalkSpeed * 0.5f * Time.deltaTime;
                transform.position += transform.right * WalkSpeed * 0.5f * Time.deltaTime;
            }
            else 
            {
                _state = 4;
                transform.position += transform.right * WalkSpeed * Time.deltaTime;
                Debug.Log("Strafe right");
                Debug.Log("State = " + _state);
            }
            
        }
        
    }
}
