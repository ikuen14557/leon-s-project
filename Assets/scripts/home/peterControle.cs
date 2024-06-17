using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peterControle : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float movespeed;
    public GameObject myBag;
    public bool isopen;
    // public Animator animator2;

    public Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 move;
    //public static Vector3 postion;

    /*
    private void Awake()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        animator2.SetBool("fadein", true);
        yield return new WaitForSeconds(1f);
        animator2.SetBool("fadein", false);
    }

    */
    void Start()
    {
        //gameObject.transform.position = postion;
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
        //animator.SetFloat("MoveValue", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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
        //postion = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        Vector2 postition = transform.position;
        postition = postition + movespeed * move * Time.fixedDeltaTime;
        //transform.position = postition;  *Time.deltaTime
        rigidbody2d.MovePosition(postition);
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