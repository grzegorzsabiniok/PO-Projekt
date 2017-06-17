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
    public virtual bool Match(Unit _unit, Type _type,object[] _parameters)
    {
        return true;
    }
}

public class POIWork : POI
{
    ItemPatern item;
    Task task;
    public POIWork(ItemPatern _item,Task _task,Vector3 _position)
    {
        task = _task;
        position = _position;
        item = _item;
        type = Type.work;
    }
    public POIWork()
    {
        item = null;
        type = Type.work;
    }
    public override bool Match(Unit _unit, Type _type)
    {
        task.Take(_unit);
        if (_type != type) return false;

       if(_unit.CheckItem(item) != -1 || item == null)
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
        if(type== _type)
        if (stockpile.slots[position] == null)
        {
            return true;

        }
        return false;
    }
    public override bool Match(Unit _unit, Type _type,object[] _paramters)
    {
        if (type == _type)
            if (stockpile.slots[position].patern == (ItemPatern)_paramters[0])
        {
            return true;

        }
        return false;
    }
}