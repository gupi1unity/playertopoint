using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _onMusic;
    [SerializeField] private Button _offMusic;

    private AudioHandler _audioHandler;

    public void Initialize(AudioHandler audioHandler)
    {
        _audioHandler = audioHandler;

        _onMusic.onClick.AddListener(_audioHandler.OnMusic);
        _offMusic.onClick.AddListener(_audioHandler.OffMusic);
    }
}
