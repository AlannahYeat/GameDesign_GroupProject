using UnityEngine;
using UnityEngine.Events;


public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private Damage.Source immunity;

    [SerializeField] private Damage.Type weakness;

    public UnityEvent<float> onDamageReceived;

    public void TakeDamage(Damage damage)
    {
        // if we're immune to this damage's source, do nothing
        if (!damage.WillAffect(immunity))
        {
            return;
        }

        // Calculate the motion value using this receiver's weakness, then signal that out to any listeners
        onDamageReceived.Invoke(damage.MotionValue(weakness));
    }
}
