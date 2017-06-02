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
        Go temp = new Go();
        Willage.willage.AddTask((
    new Task(Main.Normalize(interaction.position),
    new Action[] {
            //new Go(target.GetComponent<Tree>().interaction.position),
            new Use(transform),
            new Search(temp,-3),
            //new Go(new Vector3(60,15,182)),
            temp,
            new Drop()
})));
        Main.main.SetBlock(Main.Normalize(interaction.position), -100);
    }
}
