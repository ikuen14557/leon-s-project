using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Pice : MonoBehaviour
{
    public int index;
    public int indax;
    public Vector3 startpos;
    private void Start()
    {
        startpos = transform.position;
    }

    private void Update()
    {

    }
    private void OnMouseEnter()
    {

    }
    public bool followEnable = true;
    public bool hasPut;
    private void OnMouseDown()
    {
        if (hasPut == false)
        {
            followEnable = true;
        }
    }

    private void OnMouseDrag()
    {
        turnMap();
        if (followEnable == false) return;
        Vector3 mouepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouepos.z = 0;
        transform.position = mouepos;
    }

    private void OnMouseUp()
    {
        if (currentGrid >= 0)
        {
            if (currentGrid == index|| currentGrid == indax)
            {
                hasPut = true;
                transform.position = triggerGrid.position;
                GridManager.Instance.candleNum-=1;

            }
            else
            {
                transform.position = startpos;
            }
        }
        else
        {
            transform.position = startpos;
        }
    }
    private Transform triggerGrid;
    private int currentGrid = -1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            triggerGrid = collision.transform;
            currentGrid = int.Parse(collision.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerGrid != null && collision.gameObject == triggerGrid.gameObject)
        {
            triggerGrid = null;
            currentGrid = -1;
        }
    }

    private void turnMap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.Self);
        }
    }
}
