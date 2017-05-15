using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : Action {
public Drop()
    {

    }
    public override bool Update()
    {
        owner.DropItem();
        owner.SetAnimation("idle");
        return false;
    }
}
