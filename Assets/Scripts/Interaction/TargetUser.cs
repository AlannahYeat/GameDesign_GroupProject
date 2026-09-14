using UnityEngine;

public class TargetUser : MonoBehaviour
{
    // PROTECTED - private to everyone except the inheritING scripts
    [SerializeField] protected Transform target;

    public void SetTarget(Transform newTarget)
    {
        // Encapsulation - provide a controlled way to set data without exposing the variable to other scripts.
        target = newTarget;
    }

    public bool HasTarget()
    {
        // Abstraction - hiding unnecessary details and complexity, and providing a simple interface to get information
        return target != null;
    }

    public Vector3 DirectionToTarget()
    {
        return (target.position - transform.position).normalized;
    }

    public bool IsTargetInRange(float distance)
    {
        return Vector3.Distance(transform.position, target.position) <= distance;
    }
}
