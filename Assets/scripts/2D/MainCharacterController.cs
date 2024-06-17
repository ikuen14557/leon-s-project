using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private Animator animator;
    private Vector2 lookDirection;
    public bool isopen;
    public GameObject myBag;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift ))
        {
            moveSpeed -= 10;
        }
        if (physicsCheck.isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        OpenMyBag();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
        lookDirection = new Vector2(horizontal, 0);
        lookDirection.Normalize();
        animator.SetFloat("MoveValue", lookDirection.x);
        transform.position = position;
        
    }
    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isopen = !isopen;
            myBag.SetActive(isopen);
        }
    }
}
