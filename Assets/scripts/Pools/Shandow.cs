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

    [Header("ʱ����Ʋ���")]
    public float activeTime;//��ʾʱ��
    public float activeStart;//��ʼ��ʾʱ��

    [Header("��͸���ȿ���")]
    float alpha;
    public float alphaSet;//��ʼֵ
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
            //���ض����
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
