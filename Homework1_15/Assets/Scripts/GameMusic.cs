using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private AudioSource _audio;

    [Min(0)]
    public float musicVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    private void Update()
    {
        _audio.volume = musicVolume;
    }
}
