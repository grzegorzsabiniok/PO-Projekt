using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : Action {
public Drop()
    {

    }
    public override bool Update()
    {
        MonoBehaviour.print("rzucilem na glebe");
        task.owner.DropItem();
        Main.main.SetBlock(task.owner.transform.position, 0);
        task.owner.SetAnimation("idle");
        return false;
    }
}
