using Assets.Scripts;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public GameState GameState;

    public Platform CurrentPlatform;

    public void ReachFinish()
    {
        GameState.PlayerIsOnFinishPlatform();
        Rigidbody.velocity = Vector3.zero;

    }

    public void Bounce() 
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed,0);
    }

    internal void Die()
    {
        GameState.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
