﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 单例的基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManager<T> where T : new()
{
    private static T instance;
    
    public static T Instance{
        get {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
