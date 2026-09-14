using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : TargetUser
{
    protected NavMeshAgent agent;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SetDestination();
    }

    // virtual - you can override with new behaviour, but it does have base behaviour already defined
    public virtual void SetDestination()
    {
        if (HasTarget())
        {
            agent.SetDestination(target.position);
        }
    }
}
