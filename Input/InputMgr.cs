using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart=false;
   public InputMgr()
    {
        MonoMgr.Instance.AddUpdateListener(MyUpdate);
    }

    private void MyUpdate()
    {
        if (!isStart)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
    }
    public void StartOrEndCheck()
    {
        isStart = true;
    }

    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventMgr.Instance.EventTrigger("InputDown",key);
        }
        if (Input.GetKeyUp(key))
        {
            EventMgr.Instance.EventTrigger("InputUp", key);
        }
    }

}
