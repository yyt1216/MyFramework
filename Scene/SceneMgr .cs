using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{
    public void LoadScene(string name,UnityAction action)
    {
        SceneManager.LoadScene(name);
        action();
    }
    public void LoadSceneAsyn(string name,UnityAction action)
    {
        MonoMgr.Instance.StartCoroutine(ReallyLoadSceneAsyn(name,action));
    }
    private IEnumerator ReallyLoadSceneAsyn(string name,UnityAction action)
    {
        AsyncOperation ao=SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventMgr.Instance.EventTrigger("LoadScene",ao.progress);
            yield return ao.progress;
        }
        action();
    }
}
