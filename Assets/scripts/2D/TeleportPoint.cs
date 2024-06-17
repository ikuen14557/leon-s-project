using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportPoint : MonoBehaviour//, IInteractable
{
    public string SceneName;
    public Animator image;
    //public SceneLoadEventSO loadEventSO;
    //public Vector3 positionToGo;
    //public GameSceneSO sceneToGo;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("chuansong");

        //loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        image.SetBool("fade", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
    }
}
