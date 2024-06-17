using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManger : MonoBehaviour
{
    //轴向控制
    public bool vertical;
    public float speed = 5;
    private Rigidbody2D rigidbody;
    //正负方向控制
    private int direction = 1;
    //方向改变时间间隔
    public float changTime = 5;
    //计时器
    private float timer;
    //动画播放
    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 )
        {
            timer = changTime;
            direction = -direction;
            vertical =!vertical;
        }
    }
    private void FixedUpdate()
    {
        Vector3 pos= rigidbody .position;
        if(vertical )//垂直移动
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
            pos.y += speed * direction * Time.fixedDeltaTime;
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
            pos.x+= speed * direction * Time.fixedDeltaTime;
        }
        rigidbody .MovePosition( pos );
    }
}
