using UnityEngine;

public class CharacterOrientation : MonoBehaviour
{
    public Transform basis;

    public Vector3 Reorient(Vector3 baseDirection)
    {
        //transform.TransformDirection() takes global direction and makes it local
        return basis.TransformDirection(baseDirection);

        // this does not take into account looking up/down
        // walk slower loking up/down than you would looking straight ahead etc.s
        // you could remove the .y of the result to get a flat, horizontal vector
    }
}
