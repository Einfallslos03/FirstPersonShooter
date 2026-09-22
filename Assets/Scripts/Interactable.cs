using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    //Add or remove an InteractionEvent component to this gameobject.
    public bool useEvents;
    [SerializeField] public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }
    //this function will be called from the player
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //this is template function to be overriden by subclasses
    }
}
