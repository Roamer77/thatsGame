using System;
using UnityEngine;

public class UnitInfo
{
    public CharacterController characterController { get; }
    public Animator animator { get; }
    public UnitInfo(CharacterController characterController, Animator animator)
    {
        this.characterController = characterController;
        this.animator = animator;
    }
}