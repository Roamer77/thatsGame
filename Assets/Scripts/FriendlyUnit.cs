using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyUnit : MonoBehaviour
{
    private GameObject player;

    private Player playerState;

    public Animator animator;

    private Vector3 initialPosition;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerState = player.GetComponent<Player>();
        initialPosition = transform.position;
    }

    void Update()
    {
        checkPlayerMovementState(playerState.movementState);

        transform.position = new Vector3(player.transform.position.x + initialPosition.x , player.transform.position.y, player.transform.position.z + initialPosition.z);

        transform.rotation = player.transform.rotation;
    }


    void checkPlayerMovementState(PlayerMovementState state)
    {
        switch (state)
        {
            case PlayerMovementState.Running:
                animator.SetBool("isRunning", true);
                break;

            case PlayerMovementState.Idle:
                animator.SetBool("isRunning", false);
                break;
            default: break;

        }
    }
}
