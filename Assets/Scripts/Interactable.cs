using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when looking at an Interactable
    public string promptMessage;

    //this function will be called from the player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //this is template function to be overriden by subclasses
    }
}
