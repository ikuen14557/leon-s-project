using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class homeUI : MonoBehaviour
{
    public GameObject Button;
    //public GameObject talkUI;
    public bool collider;
    public string SceneName;
    public Animator fadeout;
    

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
            if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                //talkUI.SetActive(true);
                 StartCoroutine(FadeOutSceneRoutine());
            }
        }
    }
    
    IEnumerator  FadeOutSceneRoutine()
    {
        fadeout.SetBool("fade", true);
        yield return new WaitForSeconds(2f);
        //fadeout.SetBool("fade", false);
        //postionhom = transform.position;
        SceneManager .LoadScene(SceneName);
    }
    
}
