using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private UIController _uiController;

    [SerializeField] private AudioHandler _audioHandler;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private SoundsFX _soundsFX;

    [SerializeField] private GameObject _minePrefab;
    [SerializeField] private List<Transform> _minePositions;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Awake()
    {
        _audioHandler = new AudioHandler(_mixerGroup);
        _uiController.Initialize(_audioHandler);

        GameObject playerPrefab = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
        playerPrefab.GetComponent<PlayerController>().Initialize();

        _virtualCamera.Follow = playerPrefab.transform;

        foreach (var position in _minePositions)
        {
            GameObject mine = Instantiate(_minePrefab, position.position, Quaternion.identity);
            mine.GetComponent<Mine>().Initialize(_soundsFX);
        }
    }
}
