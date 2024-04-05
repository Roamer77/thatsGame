using System;
using UnityEngine;


[Serializable]
public class Slot
{

    public bool isEmpty { get; set; }
    public GameObject slotObject;

    public GameObject unit;

    public Slot(GameObject slotObject, GameObject unit)
    {
        this.slotObject = slotObject;
        this.unit = unit;
    }

}