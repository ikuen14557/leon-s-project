using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class talkbutton2 : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public bool collider;
    //public string SceneName;
    //public Animator fadeout;
    private void Start()
    {
        Button.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        collider = true;
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collider = false;
        Button.SetActive(false);
    }
    private void Update()
    {
        if (collider)
        {
            if (Button.activeSelf && Input.GetKeyDown(KeyCode.Q))
            {
                talkUI.SetActive(true);
                // StartCoroutine(FadeOutSceneRoutine());
            }
        }
        if (!collider)
        {
            talkUI.SetActive(false);
        }
    }
    /*
    IEnumerator  FadeOutSceneRoutine()
    {
        fadeout.SetBool("fade", true);
        yield return new WaitForSeconds(1.5f);
        fadeout.SetBool("fade", false);
        SceneManager .LoadScene(SceneName);
    }
    */
}
