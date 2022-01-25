using Assets.Scripts;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioSource _audio;

    public AudioClip ballBounce;
    [Min(0)]
    public float BounceVolume;

    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public GameState GameState;

    public Platform CurrentPlatform;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void ReachFinish()
    {
        GameState.PlayerIsOnFinishPlatform();
        Rigidbody.velocity = Vector3.zero;}

    public void Bounce() 
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed,0);
        _audio.PlayOneShot(ballBounce, BounceVolume);
    }

    internal void Die()
    {
        GameState.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

}
