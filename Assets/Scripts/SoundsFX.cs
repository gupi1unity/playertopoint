using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsFX : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void OnMineExploded()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
