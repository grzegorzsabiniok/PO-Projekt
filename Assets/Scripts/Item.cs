using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public Item(ItemPatern _patern)
    {
        patern = _patern;
    }
    public ItemPatern patern;
    public Transform mesh;
    int quality;
}
