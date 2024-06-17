using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pertercontroller : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float movespeed;
    public GameObject myBag;
    public bool isopen;



    public Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 move;
    public static  Vector3  postion;

    [Header("Dash参数")]
    public float dashTime;//冲刺时间
    float dashTimeLeft;//剩余时间
    float lastdash;//上一次冲刺时间
    public float dashCoolDown;//冷却时间
    public float dashSpeed;//冲刺速度

    bool isDash=false;



    float horizontal;
    float vertical;
    void Start()
    {
        lastdash = Time.time;
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
        gameObject.transform.position = postion;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal, vertical);
        animator.SetFloat("MoveValue", 0);
        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            animator.SetFloat("MoveValue", 1);
        }
        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        OpenMyBag();
        postion = gameObject.transform.position;

        if(Input .GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time >= (lastdash + dashCoolDown))
            {
                //可以执行dash
                ReadyToDash();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 postition = transform.position;
        postition = postition + movespeed * move * Time.fixedDeltaTime;


        rigidbody2d.MovePosition(postition);

        Dash();
    }

    void OpenMyBag()
    {
        if(Input .GetKeyDown (KeyCode.Tab))
        {
            isopen = !isopen;
            myBag .SetActive(isopen);
        }
    }


    void ReadyToDash()
    {
        isDash = true;

        dashTimeLeft = dashTime;

        lastdash = Time.time;
    }

    void Dash()
    {
        if(isDash)
        {
            if(dashTimeLeft > 0)
            {
                rigidbody2d .velocity = new Vector2(dashSpeed * horizontal, rigidbody2d.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPool.instance.GetFormPool();
            }

            else
            {
                isDash = false;
            }
        }
    }
}
