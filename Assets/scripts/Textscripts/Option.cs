using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Option : MonoBehaviour
{
    public string text;
    public UnityEngine.Events.UnityEvent onClick;
    //option.onClick.AddListener(HandleOptionClick);


    void Start()
    {
        // ���һ���¼�������� onClick �¼�
        onClick.AddListener(HandleClick);
    }


    public void HandleClick()
    {
        // ��������Ϸ����ʱ���õķ���
        Debug.Log("��Ϸ���󱻵�����");
    }
    /*   public void HandleOptionClick()
   {
       // ��ȡ��ѡѡ��
       selectedOption = option.data;

       // ������ѡѡ��ִ�в���
       switch (selectedOption)
       {
           case OptionData.Option1:
               Debug.Log("ѡ�� 1 ��ѡ��");
               break;
           case OptionData.Option2:
               Debug.Log("ѡ�� 2 ��ѡ��");
               break;
               // ...
       }
   }
    */
}
/*
public class Option1 : Option
{
    public override void Start()
    {
        text = "ѡ�� 1";
        onClick.AddListener(Option1Function);
    }

    public void Option1Function()
    {
        // ִ��ѡ�� 1 �Ĺ���
    }
}

public class Option2 : Option
{
    public override void Start()
    {
        text = "ѡ�� 2";
        onClick.AddListener(Option2Function);
    }

    public void Option2Function()
    {
        // ִ��ѡ�� 2 �Ĺ���
    }
}

public class Option3 : Option
{
    public override void Start()
    {
        text = "ѡ�� 3";
        onClick.AddListener(Option3Function);
    }

    public void Option3Function()
    {
        // ִ��ѡ�� 3 �Ĺ���
    }
}
*/