using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signalingAudio;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _deltaVolume;

    private Coroutine _coroutine;
    private float _currentVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (HasRight(other) == false)
        {
            RestartCoroutine(_minVolume, _maxVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HasRight(other) == false)
        {
            RestartCoroutine(_currentVolume, _minVolume);
        }
    }

    private void RestartCoroutine(float startVolume, float endVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(PlaySignalingAudio(startVolume, endVolume));
    }

    private bool HasRight(Collider visitor)
    {
        return visitor.GetComponent<HouseOwner>() != null;
    }

    private IEnumerator PlaySignalingAudio(float startVolume, float endVolume)
    {
        _currentVolume = startVolume;
        _signalingAudio.volume = _currentVolume;
        _signalingAudio.Play();

        while (_currentVolume != endVolume)
        {
            _signalingAudio.volume = _currentVolume;

            yield return null;

            _currentVolume = Mathf.MoveTowards(_currentVolume, endVolume, _deltaVolume * Time.deltaTime);
        }
    }
}
