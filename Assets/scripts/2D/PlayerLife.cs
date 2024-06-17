using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Death();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Death()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}

