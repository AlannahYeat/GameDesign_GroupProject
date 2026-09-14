using UnityEngine;

public class Interact : MonoBehaviour
{
    [Tooltip("Set a game object other than this one to be the object triggering the interaction.")]
    [SerializeField] private GameObject interacter;

    private Interaction currentInteraction;

    void Start()
    {
        // if we dont have an interacter set...
        if (!interacter)
        {
            // just use this game object
            interacter = gameObject;
        }
    }

    void Update()
    {
        if (currentInteraction && Input.GetKeyDown(KeyCode.E))
        {
            currentInteraction.Interact(interacter);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if we have a current interaction, dont look for a new one
        if (currentInteraction)
        {
            return;
        }

        // get the interaction component, or null if there isnt one
        currentInteraction = other.GetComponent<Interaction>();
    }

    private void OnTriggerExit(Collider other)
    {
        // if the exiting object matches our current interaction...
        if (currentInteraction == other.GetComponent<Interaction>())
        {
            // remove the current interaction
            currentInteraction = null;
        }    
    }

}
