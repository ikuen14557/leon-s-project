using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public GameObject shadowPrefab;

    public int shadowCount;

    Queue<GameObject> availableObject = new Queue<GameObject>();


    private void Awake()
    {
        instance = this;

        FillPool();//初始化对象池
    }

    public void FillPool()
    {
        for(int i=0;i<10;i++)
        {
            var newShandow = Instantiate(shadowPrefab);
            newShandow.transform.SetParent(transform);

            //取消启用
            ReturnPool(newShandow);
        }
    }


    public void ReturnPool(GameObject pool)
    {
        pool.SetActive(false);

        availableObject.Enqueue(pool);
    }

    public GameObject GetFormPool()
    {
        if(availableObject.Count == 0)
        {
            FillPool();
        }
        var outShadow = availableObject.Dequeue();

        outShadow.SetActive(true);
        return outShadow;
    }
}
