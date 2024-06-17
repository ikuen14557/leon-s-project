using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoleController : MonoBehaviour
{
    public GameObject askUI;
    public bool collider;
    public string SceneName;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        collider = true;
        //askUI.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collider = false;
        //askUI .SetActive(false);
    }
    private void Update()
    {
        if(collider&&Input.GetKeyDown (KeyCode.Space))
        {
            askUI.SetActive(true);
        }
        
    }
    public void Runin()
    {
        StartCoroutine(FadeLoade());
    }

    IEnumerator FadeLoade()
    {
        askUI.SetActive(false);
        animator.SetBool("fade", true);
        yield return new WaitForSeconds(3f);
        //animator.SetBool("fade", false);
        SceneManager.LoadScene(SceneName);
    }
    public void Runout()
    {
        askUI .SetActive(false);
    }
}
