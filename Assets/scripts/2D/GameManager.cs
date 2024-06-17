using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int candleNum = 0;
    public Text scoreText;

    private void Awake()
    {
        Instance = this;
        candleNum = 0;
    }

    private void Start()
    {
        candleNum = 0;
        scoreText = GameObject.Find("Canvas/Text").GetComponent<Text>();

    }

    private void OnGUI()
    {
        scoreText.text = candleNum.ToString();
    }
}
