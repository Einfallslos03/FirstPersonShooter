using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions inputSystem;
    private InputSystem_Actions.PlayerActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    //Start is called before the first frame update
    void Awake()
    {
        inputSystem = new InputSystem_Actions();
        onFoot = inputSystem.Player;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.StartSprint();
        onFoot.Sprint.canceled += ctx => motor.StopSprint();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value  from movement action.
        motor.ProcessMove(onFoot.Move.ReadValue<Vector3>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
