﻿using System.Collections;
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
