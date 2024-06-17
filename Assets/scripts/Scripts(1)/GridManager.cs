using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public List<Grid> allgrids;
    public int candleNum = 7;
    public string SceneName;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (candleNum == 0)
        {
            Debug.Log("Æ´Í¼Íê³É");
            SceneManager.LoadScene (SceneName);
        }
    }
}
