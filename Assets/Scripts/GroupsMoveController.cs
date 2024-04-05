using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GroupsMoveController : MonoBehaviour
{
    [SerializeField] private PlayerInput inputControl;
    [SerializeField] private List<GroupOfUnits> groupOfUnits = new List<GroupOfUnits>();

    [SerializeField] private GameObject cameraAnchorPoint;

    private InputAction inputAction;

    void Start()
    {
        inputAction = inputControl.actions.FindAction("Move");
    }


    void Update()
    {
        Vector2 inputActionValue = inputAction.ReadValue<Vector2>();

        if (inputAction.IsPressed() && (inputActionValue.x != 0 || inputActionValue.y != 0))
        {
            Vector3 newDirection = new Vector3(inputActionValue.x, 0, inputActionValue.y);
            cameraAnchorPoint.transform.position = cameraAnchorPoint.transform.position + 3 * newDirection * Time.deltaTime;

            groupOfUnits.ForEach(item =>
            {
                item.moveGroup(newDirection);
                item.setGroupMovementState(GroupMovementState.Running);

            });
        }
        else
        {
            groupOfUnits.ForEach(item =>
            {
                item.setGroupMovementState(GroupMovementState.Idle);
            });
        }
    }
}
