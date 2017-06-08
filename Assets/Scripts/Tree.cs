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
        Willage.willage.AddTask((
    new Task(Main.Normalize(interaction.position),
    new Action[] {
            //new Go(target.GetComponent<Tree>().interaction.position),
            new Use(transform),
            search,
            //new Go(new Vector3(60,15,182)),
            temp,
            new Drop(search,0)
})));
        Main.main.SetBlock(Main.Normalize(interaction.position), -100);
        Main.main.AddPOI(new POIWork(neededItem));
    }
}
