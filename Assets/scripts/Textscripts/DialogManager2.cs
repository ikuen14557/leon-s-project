using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager2 : MonoBehaviour
{
    public Text textLabel1;
    public Text textLabel2;

    public TextAsset textFile;
    public TextAsset textname;
    public int index;
    public float textspeed;

    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字
    List<string> textList = new List<string>();
    List<string> textnamelist = new List<string>();
    List<Option> options = new List<Option>();

    public GameObject optionButtonPrefab;
    public GridLayoutGroup gridGroup;

    void Awake()
    {
        GetTextFormFile(textFile, textname);
        index = 0;
    }
    

   
    private void OnEnable()
    {
        textLabel2.text = textList[index];
        index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
        
    }

    void GetTextFormFile(TextAsset file, TextAsset file1)
    {
        textList.Clear();
        textnamelist.Clear();
        options.Clear();
        index = 0;
        var lineDate1 = file1.text.Split('\n');
        foreach (var line in lineDate1)
        {
            textnamelist.Add(line);
        }

        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            if (line.StartsWith("#"))
            {
                var optionText = line.Substring(1);
                var option = new Option();
                option.text = optionText;
                options.Add(option);
            }
            else
            {
                textList.Add(line);
            }
        }
    }
    int a = 0, b = 4;
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel2.text = "";
        textLabel1.text = "";

        for (int i = 0; i < textnamelist[index].Length && !cancelTyping; i++)
        {
            textLabel1.text += textnamelist[index][i];
            yield return new WaitForSeconds(textspeed);
        }

        for (int i = 0; i < textList[index].Length && !cancelTyping; i++)
        {
            textLabel2.text += textList[index][i];
            yield return new WaitForSeconds(textspeed);
        }

        textLabel1.text = textnamelist[index];
        textLabel2.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
        Transform gridGroupTransform=gridGroup .transform;
        if(gridGroupTransform.childCount !=0)
        {
            for (int i = 0; i < gridGroupTransform.childCount; i++)
            {
                Transform child = gridGroupTransform.GetChild(i);
                Destroy(child.gameObject);
            }
        }
        // 显示选项
        if (options.Count > 0&& textList[index-1][0]=='!')
        {
            for (int i = a; i < b; i++)
            {
                var option = options[i];

                GameObject newButton = Instantiate(optionButtonPrefab, transform);
                newButton.GetComponentInChildren<Text>().text = option.text;
                //newButton.GetComponent<Button>().onClick.AddListener(() => SelectOption(option));
                newButton.transform.SetParent(gridGroup.transform);

                /*
                Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
                newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
                newItem.slotItem = item;
                newItem.slotImage.sprite = item.itemImage;
                newItem.gameObject.transform.localScale = new Vector3(1, 1, 1);
                */
            }
            a += 4; b += 4;
        }
        yield return null;
    }

    void SelectOption(Option option)
    {
        option.onClick.Invoke();
        options.Clear();
        StartCoroutine(SetTextUI());
    }
}
