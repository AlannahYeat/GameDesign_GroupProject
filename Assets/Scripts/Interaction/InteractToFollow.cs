using UnityEngine;

public class InteractToFollow : Interaction
{
    private FollowTarget follow;

    void Start()
    {
        follow = GetComponent<FollowTarget>();
    }

    public override void Interact(GameObject other)
    {
        if (follow)
        {
            //// if the follow has a target...
            //if (follow.HasTarget())
            //{
            //    // remove it
            //    follow.SetTarget(null);
            //}
            //else
            //{
            //    // else start following the interacting transform
            //    follow.SetTarget(other.transform);   
            //}

            // if the follow has a target...
            if (follow.HasTarget())
            {
                follow.SetTarget(other.transform);
                
            }
            else
            {
                follow.SetTarget(null);
            }

        }
    }

}
