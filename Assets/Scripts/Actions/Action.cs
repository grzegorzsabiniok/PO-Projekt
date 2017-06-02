using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public string name;
    public Task task;
    bool firstTime = true;
    public bool Act()
    {
        if (firstTime)
        {
            Start();
            firstTime = false;
            
        }
            return Update();
    }
    public virtual void Start()
    {

    }
    public virtual bool Update()
    {
        return false;
    }
    public virtual void Take(Task _task)
    {
        task = _task;
    }
    public virtual bool Success()
    {
        return true;
    }
}
