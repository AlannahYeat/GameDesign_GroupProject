using UnityEngine;
using UnityEngine.Events;


public class SphereColliderCollision : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something happened");
        //if (!other)
        //{
        //    return;
        //}

        if (other.tag == "Wood")
        {
            Debug.Log("Hit: " + other.transform.name);

            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }
    }
}
