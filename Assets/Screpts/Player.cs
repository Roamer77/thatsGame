using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum PlayerMovementState
{
    Running,
    Idle,
}
public class Player : MonoBehaviour
{

    private PlayerInput inputControl;

    private InputAction moveAction;

    public CharacterController charController;

    private Vector3 currentInputVector;
    private Vector2 smoothInputVelocity;

    [SerializeField] float speed;

    public Animator animator;

    public PlayerMovementState movementState;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;


        inputControl = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        moveAction = inputControl.actions.FindAction("Move");
    }
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        Vector2 input = moveAction.ReadValue<Vector2>().normalized;
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, 0.3f);
        Vector3 move = new Vector3(currentInputVector.x * speed, charController.velocity.y, currentInputVector.y * speed);


        if (moveAction.IsPressed() && (input.x != 0 || input.y != 0))
        {
            charController.Move(move * Time.deltaTime);
            if (charController.velocity != Vector3.zero)
            {

                transform.rotation = Quaternion.LookRotation(charController.velocity);
            }
            animator.SetBool("isRunning", true);
            movementState = PlayerMovementState.Running;
        }
        else
        {
            animator.SetBool("isRunning", false);
            movementState = PlayerMovementState.Idle;
        }

    }

}
