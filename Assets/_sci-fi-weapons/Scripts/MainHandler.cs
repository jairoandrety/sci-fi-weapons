using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHandler: MonoBehaviour
{
    public UIHandler uiHandler;
    public Animator _animator;

    public void ChangeScene(int sceneId)
    {
        StartCoroutine(LoadAsyncScene(sceneId));
    }

    private IEnumerator LoadAsyncScene(int sceneId)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}