using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarmEnabler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMover>(out _))
        {
            _alarmEnabler.TurnAlarmOn(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMover>(out _))
        {
            _alarmEnabler.TurnAlarmOff();
        }
    }
}
