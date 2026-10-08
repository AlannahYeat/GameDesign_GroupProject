using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool isPressed = false;
  
    public Player goblin;

    void Start()
    {
        goblin = GetComponent<Player>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isPressed == false)
        {
            return;
        }

        if (isPressed == true)
        {
            // something something countdown start
            Debug.Log("Hit: " + collision.transform.name);

            goblin.transform(0, 0, -25);
        }
    }
}
