using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public string SceneName;
    public void Changescene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
