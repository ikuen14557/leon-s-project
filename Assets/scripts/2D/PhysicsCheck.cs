using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private CapsuleCollider2D coll;
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask groundLayer;
    [Header("×´Ì¬")]
    public bool isGround;
    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
    }
    public void Update()
    {
        Check();
    }

    public void Check()
    {
        //¼ì²âµØÃæ
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);
    }
}
