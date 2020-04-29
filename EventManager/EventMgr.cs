using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{

}
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action){
        actions += action;
    }
}
public class EventMgr : BaseManager<EventMgr>
{
    public Dictionary<string, IEventInfo> eveDic=new Dictionary<string, IEventInfo>(); 

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">方法</param>
    public void AddEventListener<T>(string name,UnityAction <T> action)
    {
        if (eveDic.ContainsKey(name))
        {
            (eveDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eveDic.Add(name,new EventInfo<T>(action));
        }
    }
    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="name"></param>
    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if (eveDic.ContainsKey(name))
        {
           ( eveDic[name] as EventInfo<T> ).actions -= action;
        }
    }
    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="name">事件名</param>
    public void EventTrigger<T>(string name,T info)
    {
        if (eveDic.ContainsKey(name))
        {
            (eveDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }
    public void Clear()
    {
        eveDic.Clear();
    }
}
