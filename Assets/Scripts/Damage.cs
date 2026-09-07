using UnityEngine;

//Serialiazable means visible and editable in the unity inspector
[System.Serializable]
// structs take copies of the code to change them, unlike classes that alter the original data over every instance
public struct Damage
{
    public enum Type
    {
        Melee,
        Ranged,
        Magic,
        Elemental
    }

    public enum Source
    {
        Neutral,
        Player,
        Enemy
    }

    // serialize field makes private data available in the inspector but still private to other scripts
    [SerializeField] private float amount;

    [SerializeField] private Type type;

    [SerializeField] private Source source;

    /// <summary>
    /// The amount of health which should be lost, corresponding to the damage amount. Always negative.
    /// </summary>
    /// <returns></returns>
    public float MotionValue()
    {
        //  force 'amount' to be positive, then make sure it's negative
        return -Mathf.Abs(amount);
    }

    public float MotionValue(Type receivingWeakness)
    {
        // get your default motion value
        float mv = MotionValue();

        if (receivingWeakness == type)
        {
            mv *= 2f;
        }

        return mv;
    }


    /// <summary>
    /// Change the internal damage amount based on the time passed. Do not use more than once per damage instance.
    /// </summary>
    /// <param name="seconds"></param>
    public Damage MakePerSecond(float seconds)
    {
        // when er assign 'this', we actually assign a COPY of this
        // because structs are passed by Value (a copy is created)
        Damage damagePerSecond = this;

        damagePerSecond.amount *= seconds;

        return damagePerSecond;
    }


    /// <summary>
    /// Check if this damage will impact a receiver based on their source.
    /// </summary>
    /// <param name="receivingSource"></param>
    /// <returns></returns>
    public bool WillAffect(Source receivingSource)
    {
        return source != receivingSource;
    }
}
