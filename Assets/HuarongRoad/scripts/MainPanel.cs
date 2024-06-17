using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public static MainPanel Inst;
    public GameObject door;
    public GameObject root;
    public Animator animator;
    public GameObject three;
    private void Awake()
    {
        Inst = this;
    }
    public Button replayBtn;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        /*
        replayBtn.onClick.AddListener(() => {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        */
    }
    public void Show()//´ò¿ª²Ëµ¥
    {
        if(GameManger2 .Inst .isWin ())
        {
            StartCoroutine(fadeout());
        }
        //gameObject .SetActive (true);
    }
    
    IEnumerator fadeout()
    {
        animator.SetBool("fade", true);
        yield return new WaitForSeconds(1.85f);
        GameManger2.Inst.clear();
        gameObject.SetActive(false);
        door.SetActive(false);
        root.SetActive(false);
        three .SetActive(three);
    }
}
