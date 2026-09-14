using UnityEngine;

public class FollowTargetInRange : FollowTarget
{
    [SerializeField] private float range = 10f;

    public override void SetDestination()
    {
        // the base script version of the funtion
        //base.SetDestination();

        if (HasTarget() && IsTargetInRange(range))
        {
            agent.SetDestination(target.position);
        }
        else
        {
            // cancel any active pathing
            agent.ResetPath();
        }
    }
}
