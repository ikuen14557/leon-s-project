using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class TextManger : MonoBehaviour
{
    [Header("UI组件")]
    public Text textUI;
    [Header("文本文本")]
    public TextAsset textFile;
    int index;
    bool textFinish;
    public float textspeed;
    bool cancelTyping;
    public string SceneName;
    public Animator animator;
    List<string> textList = new List<string>();
    private void Awake()
    {
        GetTextFormDile(textFile);
    }
    private void OnEnable()
    {
        textFinish = true;
        StartCoroutine(SetTextUI());
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)&&index==textList .Count)
        {
            StartCoroutine(Fade());
            
            index = 0;
            return;
        }
        if(Input .GetKeyDown (KeyCode.Space))
        {
            if(textFinish&&!cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinish)
            {
                cancelTyping =!cancelTyping;
            }
        }
    }
    IEnumerator Fade()
    {
        animator.SetBool("fade", true);

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);

    }

    void GetTextFormDile(TextAsset textAsset)
    {
        textList .Clear();
        index = 0;
        var lineDatel = textAsset.text.Split('\n');
        foreach (var line in lineDatel)
        {
            textList .Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinish = false;
        textUI.text = "";
        for(int i = 0; i < textList[index].Length&&!cancelTyping ;i++)
        {
            textUI .text += textList[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        textUI.text = textList[index];
        textFinish = true;
        cancelTyping = false;
        index++;
    }
}
