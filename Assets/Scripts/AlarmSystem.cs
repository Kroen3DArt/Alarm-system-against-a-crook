using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _fadeSpeed = 0.3f;
    private bool _isDetected = false;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider character)
    {
        if (character.GetComponent<Rubber>())
        {
            _isDetected = true;

            if (_audioSource.isPlaying != true)
                _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider character)
    {
        if (character.GetComponent<Rubber>())
            _isDetected = false;
    }

    private void Update()
    {
        if (_isDetected == true && _audioSource.volume < _maxVolume)
        {
            ChangeVolume(_maxVolume);
        }
        else
        {
            ChangeVolume(_minVolume);

            if (_audioSource.volume == _minVolume)
                _audioSource.Stop();
        }
    }

    private void ChangeVolume(float targetVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);
    }
}
