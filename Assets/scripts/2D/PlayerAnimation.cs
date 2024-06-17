using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private MainCharacterController mainCharacterController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
    }

    private void Update()
    {
        SetAnimation(mainCharacterController);
    }

    public void SetAnimation(MainCharacterController mainCharacterController)
    {
        anim.SetFloat("MoveValue", Mathf.Abs(rb.velocity.x));
    }
}
