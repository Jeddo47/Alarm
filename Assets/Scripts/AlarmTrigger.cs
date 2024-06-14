using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] AlarmEnabler _alarmEnabler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            _alarmEnabler.TurnAlarmOn(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            _alarmEnabler.TurnAlarmOff();
        }
    }
}
