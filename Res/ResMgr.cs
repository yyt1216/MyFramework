using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr>
{
    public T Load<T>(string name) where T : Object
    {
        T obj = Resources.Load<T>(name);
        if (obj is GameObject)
            return GameObject.Instantiate(obj);
        else
            return obj;
     }
    public void LoadAsync<T>(string name,UnityAction<T> callblack) where T:Object
    {
        MonoMgr.Instance.StartCoroutine(name, callblack);
    }
    private IEnumerator RellayLoadAsync<T>(string name,UnityAction<T> callblack) where T:Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;
        if (r.asset is GameObject)
            callblack(GameObject.Instantiate(r.asset) as T);
        else
            callblack(r.asset as T);
    }

}
