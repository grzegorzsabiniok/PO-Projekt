using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Citizen : Unit, IInfo
{
    public string firstName, lastName;

    // Use this for initialization


    public void Show() { 
        if (actions.Count > 0)
        {
            infoDesc = "Spiecies: " + species + "\nSpeed: " + speed + " \nAction: " + actions[0].name;
        }
        else
        {
            infoDesc = "Spiecies: " + species + "\nSpeed: " + speed + " \nAction: nothing";
        }
        Transform temp = Transform.Instantiate(windowPrefab);
        temp.GetComponent<Window>().title.text = infoTitle;
        temp.GetComponent<Window>().desc.text = infoDesc;
        temp.GetComponent<Window>().portrait.sprite = portrait;
        temp.parent = GameObject.Find("Canvas").transform;
        print("ok");
    }
}
