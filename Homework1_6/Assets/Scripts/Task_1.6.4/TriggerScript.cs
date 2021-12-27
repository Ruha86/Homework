using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public Rigidbody leftDoor;
    public Rigidbody rightDoor;
    public float movementSpeed;

    public Vector3 leftDoorStartPos;
    public Vector3 rightDoorStartPos;

    public Vector3 leftDoorTargetPos;
    public Vector3 rightDoorTargetPos;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The doors are open.");
        DoorOpen();
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Don't linger, come on in.");
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("The doors are close.");
        DoorClose();
    }

    private void DoorOpen() 
    {
        leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorTargetPos, movementSpeed * Time.deltaTime);
        rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorTargetPos, movementSpeed * Time.deltaTime);
    }

    private void DoorClose() 
    {
        leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorStartPos, movementSpeed * Time.deltaTime);
        rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorStartPos, movementSpeed * Time.deltaTime);
    }
}
