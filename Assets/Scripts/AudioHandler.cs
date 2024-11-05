using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioHandler
{
    private const float OffVolume = -80.0f;
    private const float OnVolume = 0f;

    private const string MusicKey = "MasterVolume";

    private AudioMixerGroup _audioMixerGroup;

    public AudioHandler(AudioMixerGroup audioMixerGroup)
    {
        _audioMixerGroup = audioMixerGroup;
    }

    public void OnMusic()
    {
        _audioMixerGroup.audioMixer.SetFloat(MusicKey, OnVolume);
    }

    public void OffMusic()
    {
        _audioMixerGroup.audioMixer.SetFloat(MusicKey, OffVolume);
    }
}
