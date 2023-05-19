using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float volume = 1.0f;

    void Update()
    {
        audioSource.volume = volume;
    }
    public void SetVolume(float volume)
    {
        this.volume = volume;
    }
}
