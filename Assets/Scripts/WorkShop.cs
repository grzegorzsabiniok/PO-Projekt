using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : Structure {
    public ItemPatern[] items;
    public List<Item> storage = new List<Item>();
    public override void Use(Unit _user)
    {
        _user.AddItem(new Item(items[0]));
        //storage.RemoveAt(0);
    }
    public override void Use(Unit _user, int type)
    {
        storage.Add(_user.items[0]);
        _user.items[0] = null;
    }
    public void AddTask()
    {
        Search searchNeed = new Search(items[2]);
        Go go2 = new Go(searchNeed);
        Search search = new Search(POI.Type.stockpile);
        Go go = new Go(search);
        Willage.willage.AddTask((
    new Task(
    new Action[] {
        searchNeed,
        go2,
        new Go(Main.Normalize(interaction.position)),
            new Use(transform),
            search,
            go,
            new Drop(search,0)
})));


        Main.main.SetBlock(Main.Normalize(interaction.position), -100);
        Main.main.AddPOI(new POIWork());
    }
}
