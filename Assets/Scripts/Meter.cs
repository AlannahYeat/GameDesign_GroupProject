using UnityEngine;
using UnityEngine.Events;  // gives access to unity events

public class Meter : MonoBehaviour
{
    public float valueMaximum;

    public float valueCurrent;

    public bool isFullOnStart;

    public UnityEvent onFull;

    public UnityEvent onEmpty;

    // pass a float through when this event is invoked
    public UnityEvent<float> onChange;

    void Start()
    {
        if (isFullOnStart)
        {
            Fill();
        }
    }

    public void Adjust(float amount)
    {
        valueCurrent = Mathf.Clamp(valueCurrent + amount, 0, valueMaximum);

        // percentages in programming are between 0.0 and 0.1
        // pass through the percent remaining in the meter
        onChange.Invoke(valueCurrent / valueMaximum);

        // if the meter is at maximum after the change...
        if (valueCurrent == valueMaximum)
        {
            // invoke the event
            onFull.Invoke();   
        }

        if (valueCurrent ==0)
        {
            onEmpty.Invoke();
        }
    }

    public void Fill()
    {
        valueCurrent = valueMaximum;
        onFull.Invoke();
    }

    public void Empty()
    {
        valueCurrent = 0;
        onEmpty.Invoke();
    }

    public void Set(float value)
    {
        valueCurrent = Mathf.Clamp(value, 0, valueMaximum);
    }
}
