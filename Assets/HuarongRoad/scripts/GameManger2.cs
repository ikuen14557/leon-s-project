using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class GameManger2 : MonoBehaviour
{
   // public MainPanel mainPanel;
    public static GameManger2 Inst;
    public GameObject CeilItem;
    public List<Sprite> mapSps;
    public int row = 3;//行
    public int col = 3;//列
   
    //洗牌
    
    void WashNumbers(List <int>listObj)
    {
        //模拟法
        int q = Random.Range(1, 51);
        int zerolocation = 8;
        while(q>0)
        {
            int j = Random.Range(0, listObj.Count);
            if(j==zerolocation -3||j==zerolocation -1||j==zerolocation +1||j==zerolocation +3)
            {
                q--;
                int temp = listObj[zerolocation ];
                listObj[zerolocation ]= listObj[j];
                listObj[j] = temp;
                zerolocation = j;
            }
        }
        while (zerolocation !=8)
        {
            int j = Random.Range(0, listObj.Count);
            if (j == zerolocation - 3 || j == zerolocation - 1 || j == zerolocation + 1 || j == zerolocation + 3)
            {
                int temp = listObj[zerolocation];
                listObj[zerolocation] = listObj[j];
                listObj[j] = temp;
                zerolocation = j;
            }
        }
    }
    public List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

    //key是number
    private Dictionary<int, CeilItem> dataDict = new Dictionary<int, CeilItem>();

    public void clear()
    {
        foreach (var pair in dataDict)
        {
            // 获取 GameObject 的引用
            GameObject go = pair.Value.gameObject;

            // 销毁 GameObject
            Destroy(go);
        }
    }
    CeilItem findCeilItem(int rIdx, int cIdx)
    {
        foreach (KeyValuePair<int, CeilItem> kv in dataDict)
        {
            if (kv.Value.rInx == rIdx && kv.Value.cIdx == cIdx)
            {
                return kv.Value;
            }
        }
        return null;
    }


    Vector3 getCeilItemPos(int i, int j)
    {
        Vector3 ve = default;
        ve.x = j;
        ve.y = -1 * i;
        return ve;
    }
    //检查格子是否合规
    bool checkCeilRight(int rIdex, int cIdex)
    {
        if (rIdex < 0 || rIdex >= row || cIdex < 0 || cIdex >= col)
        {
            return false;
        }
        return true;
    }
    //执行一次是否能查找空格子
    bool findOneZeroCeil(int rIdx, int cIdx)
    {
        if (!checkCeilRight(rIdx, cIdx))
        {
            return false;
        }
        CeilItem ceil = findCeilItem(rIdx, cIdx);

        if (ceil != null)
        {
            return ceil.number == 0;
        }
        return false;
    }

    public (int, int) findfourZeroCel(int rIdx, int cIdx)
    {
        List<(int, int)> dirs = new List<(int, int)>()
        {
            (rIdx + 1, cIdx),
            (rIdx - 1, cIdx),
            (rIdx, cIdx + 1),
            (rIdx, cIdx - 1)
        };
        for (int i = 0; i < dirs.Count; i++)
        {
            (int, int) item = dirs[i];
            if (findOneZeroCeil(item.Item1, item.Item2))
            {
                return item;
            }
        }
        return (999, 999);
    }

    //检查是否可以交换
    public void CheckSwap(int rIdx, int cIdx, int clickCeilNumber)
    {
        (int, int) res = findfourZeroCel(rIdx, cIdx);
        if (res.Item1 != 999)
        {
            StartSwap(clickCeilNumber, 0);
        }
    }

    void StartSwap(int clickNumber, int zeroNumber)
    {
        CeilItem clickItem = dataDict[clickNumber];
        CeilItem zeroItem = dataDict[0];

        Vector3 clickPos = clickItem.transform.position;
        clickItem.transform.position = zeroItem.transform.position;
        zeroItem.transform.position = clickPos;
        SwapData(clickItem, zeroItem);
    }

    void SwapData(CeilItem clickItem, CeilItem zeroItem)
    {
        var clickRIdx = clickItem.rInx;
        var clickCIdx = clickItem.cIdx;
        clickItem.updateRandCIdx(zeroItem.rInx, zeroItem.cIdx);
        zeroItem.updateRandCIdx(clickRIdx, clickCIdx);
        //isWin();
    }

    public bool isWin()
    {
        bool res = false;
        int startNum = 1;
        int maxNum = row * col;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var ceil = findCeilItem(i, j);
                if (startNum ==maxNum )
                {
                    res = ceil.number ==0;
                    continue;
                }
                if(ceil .number != startNum)
                {
                    return res;
                }
                startNum ++;
            }
        }
        if(res)
        {
            Debug.Log("游戏胜利");
        }
        return res;
    }
        void InitMap()
        {
            WashNumbers(numbers);
            int numberIdx = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Vector3 pos = getCeilItemPos(i, j);
                    var go = GameObject.Instantiate(CeilItem, pos, Quaternion.identity);
                    var ceilItem = go.GetComponent<CeilItem>();
                    int number = numbers[numberIdx];
                    ceilItem.Init(number, i, j);
                    dataDict.Add(number, ceilItem);
                    numberIdx++;
                }
            }
        }
       
        void Awake()
        {
            Inst = this; ;
        }
        void Start()
        {
            InitMap();
        }
}
