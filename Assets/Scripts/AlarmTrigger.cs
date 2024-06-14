using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    public event Action<float> ThiefEntered;
    public event Action<float> ThiefLeft;

    public float MinVolume { get { return _minVolume; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            ThiefEntered?.Invoke(_maxVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            ThiefLeft?.Invoke(_minVolume);
        }
    }
}
