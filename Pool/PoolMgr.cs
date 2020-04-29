
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolData{
    public GameObject FatherObj;
    public List<GameObject> poollist;
    public PoolData(GameObject obj,GameObject  poolObj)
    {
        FatherObj = new GameObject(obj.name);
        FatherObj.transform.parent = poolObj.transform;
        poollist = new List<GameObject>() { obj};
    }
    public void Recycly(GameObject obj)
    {
        obj.SetActive(false);
        poollist.Add(obj);
        obj.transform.parent = FatherObj.transform;
    }
    public GameObject GetObj()
    {
        GameObject obj=null;
        obj = poollist[0];
        poollist.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;

        return obj;
    }
}
public class PoolMgr :BaseManager<PoolMgr>
{
    private Dictionary<string,PoolData> pool=new Dictionary<string, PoolData>();
 
    private GameObject PoolObj;
    public void GetObj(string ObjName,UnityAction<GameObject> callblack)
    {
        if (pool.ContainsKey(ObjName) && pool[ObjName].poollist.Count>0)
        {
            callblack(pool[ObjName].GetObj());
        }
        else
        {
            ResMgr.Instance.LoadAsync<GameObject>(ObjName,(O)=> {
                O.name = ObjName;
                callblack(O);
            });
        }
    }
    public void RecycleObj(GameObject obj)
    {
        if (PoolObj == null)
            PoolObj = new GameObject("PoolObj") ;

        obj.transform.parent = PoolObj.transform;

        if (pool.ContainsKey(obj.name))
        {
            pool[obj.name].Recycly(obj);
        }
        else
        {
            pool.Add(obj.name,new PoolData(obj,PoolObj));
            obj.SetActive(false);
        }
    }
    /// <summary>
    /// 切换场景清除
    /// </summary>
    public void Clear()
    {
        pool.Clear();
        PoolObj = null;
    }
}
