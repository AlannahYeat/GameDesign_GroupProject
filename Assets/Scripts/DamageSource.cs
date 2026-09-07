using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public enum Applied
    {
        Instantly,
        PerSecond
    }

    public Damage damage;

    public Applied applied;

    private void TryApplyDamage(GameObject target, Applied context)
    {

        // i.e. if we are instant, and the context is per time, do nothing
        if (context != applied)
        {
            return;
        }

        // if the target can receive damage...
        if (target.GetComponent<DamageReceiver>())
        {
            float amountApplied = 1f;

            // if we should do damage over time...
            if (applied == Applied.PerSecond)
            {
                amountApplied = Time.fixedDeltaTime;
            }

            target.GetComponent<DamageReceiver>().TakeDamage(damage.MakePerSecond(amountApplied));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // apply damage to the colliding gameobject, if this damage source is instant
        TryApplyDamage(collision.gameObject, Applied.Instantly);
    }

    private void OnCollisionStay(Collision collision)
    {
        TryApplyDamage(collision.gameObject, Applied.PerSecond);
    }

    private void OnTriggerEnter(Collider other)
    {
        TryApplyDamage(other.gameObject, Applied.Instantly);
    }

    private void OnTriggerStay(Collider other)
    {
        TryApplyDamage(other.gameObject, Applied.PerSecond);
    }

    private void OnParticleCollision(GameObject other)
    {
        TryApplyDamage(other, Applied.Instantly);
    }
}
