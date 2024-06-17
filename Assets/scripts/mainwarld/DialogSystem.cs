using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header ("UI组件")]
    public Text textLabel1;
    public Text textLabel2;

    [Header ("文本文件")]
    public TextAsset textFile;
    public TextAsset textname;
    public int index;
    public float textspeed;

    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字
    List<string> textList = new List<string>();
    List<string> textnamelist = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFormFile(textFile,textname);
        //index = 0;
    }
    private void OnEnable()
    {
        //textLabel2.text  = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        //if (Input.GetKeyDown(KeyCode.Space)&&textFinished )
        //{
        //textLabel2.text = textList[index];
        //index++;
        //StartCoroutine(SetTextUI());
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(textFinished &&!cancelTyping )
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }
    void GetTextFormFile(TextAsset file,TextAsset file1)
    {
        textList.Clear();
        textnamelist.Clear();  
        index = 0;
        var lineDate1 = file1.text.Split('\n');
        foreach (var line in lineDate1)
        {
            textnamelist.Add(line);
        }
        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {

            textList.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel2.text = "";
        textLabel1.text = "";
        //for(int i = 0; i < textList[index].Length;i++)
        //{
        // textLabel2.text += textList[index][i];
        // yield return new WaitForSeconds(textspeed);
        // }
        for (int i = 0; i < textnamelist[index].Length&&!cancelTyping ; i++)
        {
            textLabel1.text += textnamelist[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        for (int i = 0; i < textList[index].Length&&!cancelTyping ; i++)
        {
            textLabel2.text += textList[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        textLabel1.text = textnamelist[index];
        textLabel2.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
