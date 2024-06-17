using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class StartManger : MonoBehaviour
{
    public Animator  animator;
    public Animator animator2;
    AnimatorStateInfo stateinfo;
    public string SceneName;
    public Image image;
    bool isclose;
    public float fadeSpeed=1f;
    public GameObject gameObject;

    void Start()
    {
        gameObject .SetActive(true);

    }

    
    void Update()
    {
        stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        if (isAniEnd())
        {
            gameObject .SetActive(false);
        }
    }

    IEnumerator FadeImage()
    {
        float alpha = image.color.a;

        // 循环直至 alpha 达到 0
        while (alpha > 0)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
    }
    private bool isAniEnd()
    {
        if (  stateinfo.normalizedTime >= 1.0f)
        {
            return true;
        }
        else if ( stateinfo.normalizedTime <= 0.0f)
        {
            return false;
        }
        return false;
    }
    

    public void ChangScene()
    {
        StartCoroutine(FadeoutScene());
    }
    IEnumerator FadeoutScene()
    {
        animator2 .SetBool ("fadeout", false);
        yield return new WaitForSeconds(2f);
        SceneManager .LoadScene (SceneName);
    }
}