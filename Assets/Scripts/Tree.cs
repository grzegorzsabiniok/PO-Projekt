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
}
