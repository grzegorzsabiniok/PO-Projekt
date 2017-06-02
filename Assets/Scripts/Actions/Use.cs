using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : Action {
    public Transform target;
    bool succes = true;
    float animationTime = 0;
public Use(Transform _target)
    {
        target = _target;
    }
    public override void Start()
    {
        
        if (Main.Normalize(task.owner.transform.position) == Main.Normalize(target.GetComponent<Structure>().interaction.position))
        {
            task.owner.transform.rotation = target.GetComponent<Structure>().interaction.rotation;
            task.owner.SetAnimation(target.GetComponent<Structure>().useAnimation);
            task.owner.UseItem(target.GetComponent<Structure>().neededItem);
        }
    }
    public override bool Update()
    {
        if(target.GetComponent<Structure>().neededItem != null)
        if (task.owner.CheckItem(target.GetComponent<Structure>().neededItem) == -1)
        {
            succes = false;
            return false;
            
        }
        if (Main.Normalize(task.owner.transform.position) == Main.Normalize(target.GetComponent<Structure>().interaction.position))
        {
            
            animationTime += Time.deltaTime;
            if (animationTime > target.GetComponent<Structure>().timeAnimation)
            {
                
                target.GetComponent<Structure>().Use(task.owner);
                task.owner.SetAnimation("idle");
                task.owner.ItemToBackpack();
                return false;
            }
        }
        else
        {
            succes = false;
            return false;
        }
        return true;
        
    }
    public override bool Success()
    {
        return succes;
    }
}
