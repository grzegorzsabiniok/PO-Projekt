using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : Action {
    POI poi;
    int item;
    Search search;
public Drop()
    {

    }
    public Drop(POI _poi,int _item)
    {
        poi = _poi;
        item = _item;
    }
    public Drop(Search _search,int _item)
    {
        search = _search;
        item = _item;
    }
    public override void Start()
    {
        poi = search.poi;
    }
    public override bool Update()
    {
        if(poi != null)
        {
            ((POIStockpile)poi).stockpile.slots[task.owner.transform.position] = task.owner.items[item];
        }
        task.owner.DropItem();
        //Main.main.SetBlock(task.owner.transform.position, 0);
        task.owner.SetAnimation("idle");
        return false;
    }
}
