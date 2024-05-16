using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _fadeSpeed = 0.3f;

    private Coroutine _volumeCoroutine;

    private void Awake()
    {
       _audioSource.volume = _minVolume;
    }

    public void PlaySound()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _audioSource.Play();
        _volumeCoroutine = StartCoroutine(ChangingVolume(_maxVolume));
    }

    public void StopSound()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangingVolume(_minVolume));

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }

    public void ChangeVolume(float targetVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);
    }

    private IEnumerator ChangingVolume(float targetVolume)
    {
        float currentVolume = _audioSource.volume;
        float minDifference = 0.1f;

        while (Mathf.Abs(currentVolume - targetVolume) > minDifference)
        {
            ChangeVolume(targetVolume);
            yield return null;
        }

        _audioSource.volume = targetVolume;
    }
}
