using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class homeManger : MonoBehaviour
{
    public string SceneName;
    public Animator animator;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(fadeout());
    }

    IEnumerator fadeout()
    {
        
        animator.SetBool("fade", false);
        yield return new WaitForSeconds(1.5f);
        /*
        // 获取角色的 Transform 组件
        Transform playerTransform = player.transform;

        // 获取出生点的 Transform 组件
        Transform spawnPointTransform = GameObject.Find("SpawnPoint").transform;

        // 设置角色的 Transform 属性以匹配出生点
        playerTransform.position = spawnPointTransform.position;
        playerTransform.rotation = spawnPointTransform.rotation;

        // 加载新场景
        */
        SceneManager.LoadScene(SceneName);
     }
}
