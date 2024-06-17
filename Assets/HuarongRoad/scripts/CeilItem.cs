using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilItem : MonoBehaviour
{
    public  int rInx { get; private set; }
    public  int cIdx { get; private set; }
    public  int number;
    private SpriteRenderer sp;
    public static CeilItem instance;

    private void Awake()
    {
        instance = this;
        sp = GetComponent<SpriteRenderer>();
    }
    public void Init(int number, int rInx,int cIndx)
    {
        this.number = number;
        this.rInx = rInx;
        this.cIdx = cIndx;
        UpdateSP(this.number);
    }

    public void updateRandCIdx(int rIdx,int cIdx)
    {
        this.rInx=rIdx;
        this.cIdx = cIdx;
    }
    private void OnMouseDown()
    {
        if (number == 0)
            return;
        GameManger2.Inst.CheckSwap(rInx, cIdx,number);
    }

    public  void UpdateSP(int number)
    {
       if(number==0)
        {
            sp.sprite = null;
        }
        else
        {
            int idx = number - 1;
            sp.sprite = GameManger2.Inst.mapSps[idx];
        }
    }
}
