using UnityEngine;

public class InputButton
{
    public InputButton(string action)    //this is a constructor. format it like this.
    {
        this.action = action;
    }

    // this will hold the name of an input action, e.g. "jump", "sprint"
    private string action;


    /// <summary>
    /// check if the button was pressed this frame.
    /// </summary>
    /// <returns>True if button is pressed, else false.</returns>
    public bool WasPressed()
    {
        return Input.GetButtonDown(action);
    }


    /// <summary>
    /// Check if the button is currently held down.
    /// </summary>
    /// <returns></returns>
    public bool IsHeld()
    {
        return Input.GetButton(action);
    }

    /// <summary>
    /// Check if the button was released this frame.
    /// </summary>
    /// <returns></returns>
    public bool WasReleased()
    {
        return Input.GetButtonUp(action);
    }
}
