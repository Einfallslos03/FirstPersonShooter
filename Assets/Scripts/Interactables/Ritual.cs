using UnityEngine;

public class Ritual : Interactable
{
    public PlayerHealthBar player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        player.TakeDamage(20);
    }
}
