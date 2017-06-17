using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Structure {
    public Transform trunk;
    public ItemPatern wood;
    public override void Use(Unit _user)
    {
        _user.AddItem(new Item(wood));
        Transform temp = Transform.Instantiate(trunk);
        temp.position = transform.position;
        DeleteColiders();
        Destroy(gameObject);
    }
    public void Chop()
    {
        
        Search search = new Search(POI.Type.stockpile);
        Go temp = new Go(search);
        /*Willage.willage.AddTask((
    new Task(Main.Normalize(interaction.position),
    new Action[] {
            new Use(transform),
            search,
            temp,
            new Drop(search,0)
})));
*/
Task chop = new Task(Main.Normalize(interaction.position),
    new Action[] {
        new Go(Main.Normalize(interaction.position)),
            new Use(transform),
            search,
            temp,
            new Drop(search,0)
});
        Main.main.SetBlock(Main.Normalize(interaction.position), -100);
        Main.main.AddPOI(new POIWork(neededItem,chop, Main.Normalize(interaction.position)));
    }
}
