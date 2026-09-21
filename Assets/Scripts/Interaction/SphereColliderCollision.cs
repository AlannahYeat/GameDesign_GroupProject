using UnityEngine;
using UnityEngine.Events;


public class SphereColliderCollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        //if (!other)
        //{
        //    return;
        //}

        if (collision.gameObject.tag == "Wood")
        {
            Debug.Log("Hit: " + collision.transform.name);

            Destroy(collision.gameObject);

            Destroy(this.gameObject);
        }
    }
}
