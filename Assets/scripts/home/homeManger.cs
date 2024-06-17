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
        // ��ȡ��ɫ�� Transform ���
        Transform playerTransform = player.transform;

        // ��ȡ������� Transform ���
        Transform spawnPointTransform = GameObject.Find("SpawnPoint").transform;

        // ���ý�ɫ�� Transform ������ƥ�������
        playerTransform.position = spawnPointTransform.position;
        playerTransform.rotation = spawnPointTransform.rotation;

        // �����³���
        */
        SceneManager.LoadScene(SceneName);
     }
}
