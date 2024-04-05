using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRoadPart : MonoBehaviour
{
    public GameObject movablePlatform;
    public GameObject currentPlatform;

    public float platformSize;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float z = currentPlatform.transform.position.z + platformSize;

            movablePlatform.transform.position = new Vector3(movablePlatform.transform.position.x, movablePlatform.transform.position.y, z);
        }


    }
}
