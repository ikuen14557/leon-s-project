using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Shandow : MonoBehaviour
{
    Transform player;

    SpriteRenderer thisSprite;
    SpriteRenderer playerSprite;

    Color color;

    [Header("时间控制参数")]
    public float activeTime;//显示时间
    public float activeStart;//开始显示时间

    [Header("不透明度控制")]
    float alpha;
    public float alphaSet;//初始值
    public float alphaMultiplier;


    private void OnEnable()
    {
        player = GameObject.Find("peter").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite =player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        transform.localScale = player.transform.localScale;


        activeStart = Time.time;
    }


    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1, 1, 1, alpha);

        thisSprite.color = color;

        if(Time.time >= activeTime+activeStart)
        {
            //返回对象池
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
