using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private VolumeChanger _volumeChanger;

    private void OnTriggerEnter(Collider character)
    {
        if (character.GetComponent<Rubber>())
            _volumeChanger.PlaySound();
    }

    private void OnTriggerExit(Collider character)
    {
        if (character.GetComponent<Rubber>())
            _volumeChanger.StopSound();
    }
}
