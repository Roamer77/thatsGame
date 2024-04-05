using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 cameraOffset;

    void Start()
    {
        //cameraOffset = new Vector3(0, 8, -12);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
