using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public Unit owner;
    public string name;
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
    public virtual void Take(Unit _owner)
    {
        owner = _owner;
    }
    public virtual bool Success()
    {
        return true;
    }
}
