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
        // 添加一个事件处理程序到 onClick 事件
        onClick.AddListener(HandleClick);
    }


    public void HandleClick()
    {
        // 当单击游戏对象时调用的方法
        Debug.Log("游戏对象被单击！");
    }
    /*   public void HandleOptionClick()
   {
       // 获取所选选项
       selectedOption = option.data;

       // 根据所选选项执行操作
       switch (selectedOption)
       {
           case OptionData.Option1:
               Debug.Log("选项 1 被选中");
               break;
           case OptionData.Option2:
               Debug.Log("选项 2 被选中");
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
        text = "选项 1";
        onClick.AddListener(Option1Function);
    }

    public void Option1Function()
    {
        // 执行选项 1 的功能
    }
}

public class Option2 : Option
{
    public override void Start()
    {
        text = "选项 2";
        onClick.AddListener(Option2Function);
    }

    public void Option2Function()
    {
        // 执行选项 2 的功能
    }
}

public class Option3 : Option
{
    public override void Start()
    {
        text = "选项 3";
        onClick.AddListener(Option3Function);
    }

    public void Option3Function()
    {
        // 执行选项 3 的功能
    }
}
*/