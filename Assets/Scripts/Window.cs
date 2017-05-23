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
            Willage.willage.AddTask((
                new Task(target.GetComponent<Tree>().interaction.position,
                new Action[] {
            //new Go(target.GetComponent<Tree>().interaction.position),
            new Use(target),
            new Go(new Vector3(60,15,182)),
            new Drop()
            })));
            Main.main.SetBlock(Main.Normalize(target.GetComponent<Tree>().interaction.position), -100);
        }
    }
}
