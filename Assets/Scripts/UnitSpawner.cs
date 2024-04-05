using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{

    public int amount;

    public GameObject unitPrefab;

    private bool isTriggered;

    void Start()
    {
        isTriggered = false;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isTriggered)
        {
           
            isTriggered = true;
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

}
