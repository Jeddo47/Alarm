using System.Collections;
using UnityEngine;

public class AlarmEnabler : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField] private float _volumeChangeDelay;

    private Coroutine _volumeChangeCoroutine;
    private bool _isAlarmEnabled = false;

    private void OnEnable()
    {
        _alarmTrigger.ThiefEntered += ChangeAlarmStatus;
        _alarmTrigger.ThiefLeft += ChangeAlarmStatus;
    }

    private void OnDisable()
    {
        _alarmTrigger.ThiefEntered -= ChangeAlarmStatus;
        _alarmTrigger.ThiefLeft -= ChangeAlarmStatus;
    }

    private void ChangeAlarmStatus(float targetVolume) 
    {
        if (_volumeChangeCoroutine != null) 
        {
            StopCoroutine(_volumeChangeCoroutine);        
        }
        
        _volumeChangeCoroutine = StartCoroutine(StartChangingVolume(targetVolume));
    }

    private IEnumerator StartChangingVolume(float targetVolume) 
    {
        WaitForSeconds wait = new WaitForSeconds(_volumeChangeDelay);

        if (_isAlarmEnabled == false)
        {
            _isAlarmEnabled = true;

            _audioSource.Play();
        }

        while (_audioSource.volume != targetVolume) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeSpeed);

            yield return wait;
        }

        if (_audioSource.volume == _alarmTrigger.MinVolume) 
        {
            _isAlarmEnabled = false;
            
            _audioSource.Stop();        
        }
    }
}
