using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI{
    public Type type;
    public Vector3 position;
public enum Type
    {
        work,
        food,
        stockpile
    }
    public virtual bool Match(Unit _unit, Type _type)
    {
        return true;
    }
}

public class POIWork : POI
{
    ItemPatern item;
    public POIWork(ItemPatern _item)
    {
        item = _item;
        type = Type.work;
    }
    public override bool Match(Unit _unit, Type _type)
    {
       if(_unit.CheckItem(item) != -1 && _type == type)
        {
            return true;
        }
        return false;
    }
}
public class POIStockpile : POI
{
    public Stockpile stockpile;
    public POIStockpile(Stockpile _stockpile,Vector3 _position)
    {
        position = Main.Normalize(_position);
        type = Type.stockpile;
        stockpile = _stockpile;
    }
    public override bool Match(Unit _unit, Type _type)
    {
        MonoBehaviour.print(stockpile.slots[position]);
        if (stockpile.slots[position] == null)
        {
            return true;

        }
        return false;
    }
}