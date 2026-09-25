using UnityEngine;
using UnityEngine.AI;
public class Keypad : Interactable
{
    [SerializeField] private GameObject door;
    [SerializeField] private NavMeshObstacle obstacleLeft;
    [SerializeField] private NavMeshObstacle obstacleRight;
    private bool doorOpen;
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
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        obstacleLeft.enabled = !doorOpen;
        obstacleRight.enabled = !doorOpen;
    }
}
