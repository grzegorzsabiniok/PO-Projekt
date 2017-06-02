using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Window : MonoBehaviour{
    public Text title, desc;
    public Image portrait;
    public Transform target;
    public void Exit()
    {
        Destroy(transform.gameObject);
    }
    public void CutTree()
    {
        if (Main.main.GetBlock(target.GetComponent<Tree>().interaction.position) == 0)
        {
            target.GetComponent<Tree>().Chop();
        }
    }
    public void Craft()
    {
        if (Main.main.GetBlock(target.GetComponent<WorkShop>().interaction.position) <=0)
        {
            target.GetComponent<WorkShop>().AddTask();
        }
    }
}
