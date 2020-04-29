
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : BaseManager<MonoMgr>
{
    private MonoController Controller;

    public MonoMgr()
    {
        GameObject obj = new GameObject("MonoController");
        Controller = obj.AddComponent<MonoController>();
    }
    public void AddUpdateListener(UnityAction fun)
    {
        Controller.AddUpdateListener(fun);
    }
    public void RemoveUpdateListener(UnityAction fun)
    {
        Controller.RemoveUpdateListener(fun);
    }
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return Controller.StartCoroutine(routine);
    }
    public Coroutine StartCoroutine(string methodName)
    {
        return Controller.StartCoroutine(methodName);
    }
    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return Controller.StartCoroutine(methodName,value);
    }
    public Coroutine StartCoroutine_Auto(IEnumerator routine)
    {
        return Controller.StartCoroutine(routine);
    }

    public void StopCoroutine(string methodName)
    {
        Controller.StopCoroutine(methodName);
    }
    public void StopCoroutine(IEnumerator routine)
    {
        Controller.StopCoroutine(routine);
    }
    public void StopCoroutine(Coroutine routine)
    {
        Controller.StopCoroutine(routine);
    }
    public void StopAllCoroutines()
    {
        Controller.StopAllCoroutines();
    }
}
