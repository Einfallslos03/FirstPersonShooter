using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions inputSystem;
    public InputSystem_Actions.PlayerActions playerAction;

    private PlayerMotor motor;
    private PlayerLook look;
    private Weapon weapon;
    //Start is called before the first frame update
    void Awake()
    {
        inputSystem = new InputSystem_Actions();
        playerAction = inputSystem.Player;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        weapon = GetComponentInChildren<Weapon>();

        playerAction.Jump.performed += ctx => motor.Jump();
        playerAction.Crouch.performed += ctx => motor.Crouch();
        playerAction.Sprint.performed += ctx => motor.StartSprint();
        playerAction.Sprint.canceled += ctx => motor.StopSprint();

        playerAction.Attack.performed += ctx => weapon.OnFireInput(true);
        playerAction.Attack.canceled += ctx => weapon.OnFireInput(false);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value  from movement action.
        motor.ProcessMove(playerAction.Move.ReadValue<Vector3>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(playerAction.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        playerAction.Enable();
    }
    private void OnDisable()
    {
        playerAction.Disable();
    }
}
