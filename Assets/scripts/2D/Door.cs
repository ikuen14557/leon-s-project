using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.candleNum >= 5)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (GameManager.Instance.candleNum <= 4)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}

