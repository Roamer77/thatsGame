using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public enum GroupMovementState
{
    Running,
    Idle,
}

public class GroupOfUnits : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3;

    private List<UnitInfo> unitsInfo = new List<UnitInfo>(3);

    [SerializeField] private List<Slot> slots = new List<Slot>(3);

    private float gravity = 20;

    private float gravityEffect;

    private GroupMovementState groupMovementState = GroupMovementState.Idle;

    void Start()
    {
        foreach (var item in slots)
        {
            unitsInfo.Add(new UnitInfo(item.unit.GetComponent<CharacterController>(), item.unit.GetComponent<Animator>()));
        }
    }

    void Update()
    {
        unitsInfo.ForEach(item =>
        {
            gravityHandling(item.characterController);
        });
        if (groupMovementState == GroupMovementState.Running)
        {
            unitsInfo.ForEach(item =>
            {
                item.animator.SetBool("isRunning", true);
            });
        }
        else
        {
            unitsInfo.ForEach(item =>
           {
               item.animator.SetBool("isRunning", false);
           });
        }
    }

    public void moveGroup(Vector3 moveDirection)
    {
        unitsInfo.ForEach(item =>
        {
            moveUnit(moveDirection, item.characterController);
            rotateUnit(moveDirection, item.characterController);
        });
    }

    public void setGroupMovementState(GroupMovementState state)
    {
        groupMovementState = state;
    }

    private void moveUnit(Vector3 moveDirection, CharacterController unit)
    {
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = gravityEffect;

        unit.Move(moveDirection * Time.deltaTime);
    }

    private void rotateUnit(Vector3 moveDirection, CharacterController unit)
    {
        if (unit.isGrounded)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, 1, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }

    private void gravityHandling(CharacterController unit)
    {
        if (!unit.isGrounded)
        {
            gravityEffect -= gravity * Time.deltaTime;
        }
        else
        {
            gravityEffect = 0;
        }
    }

}
