using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    [Header("Speed")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float crouchSpeed = 2f;
    public float speed;
    private bool isGrounded;
    public bool lerpCrouch = false;
    public bool crouching;
    public bool sprinting;

    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    public float crouchTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
    // receive the inputs for InputManager.cs and apply them to character controller.
    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.y = input.y;
        moveDirection.z = input.z;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(speed);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
        UpdateSpeed();
    }
    public void StartSprint()
    {
        if (crouching) return;
        sprinting = true;
        UpdateSpeed();
    }

    public void StopSprint()
    {
        sprinting = false;
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        if (crouching)
            speed = crouchSpeed;
        else if (sprinting)
            speed = sprintSpeed;
        else
            speed = walkSpeed;
    }
}
