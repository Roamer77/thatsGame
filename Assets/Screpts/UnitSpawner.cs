using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSwapnBrps : MonoBehaviour
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
            spawnUnitOnCalculatedPositions(other.transform.position, 2);
            isTriggered = true;
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    void spawnUnitOnCalculatedPositions(Vector3 position, int rows)
    {
        int unitCount = 0;
        for (int z = 0; z <= rows; z++)
        {
            for (int x = 0; x <= 2 * rows - 1; x++)
            {

                if (x >= rows - (z - 1) && x <= rows + (z - 1))
                {
                    unitCount++;
                    if (unitCount > 1)
                    {
                        Vector3 newPosition = new Vector3(position.x - x , position.y, -z +1);
                        Instantiate(unitPrefab, newPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}
