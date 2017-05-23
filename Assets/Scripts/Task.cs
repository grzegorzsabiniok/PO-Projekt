using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task {
    public Vector3 position;
    public Unit owner;
    public List<Action> toDo = new List<Action>();
    public Task(Vector3 _position,Action[] actions)
    {
        owner = null;
        position = Main.Normalize(_position);
        toDo = new List<Action>(actions);
    }

    public void Take(Unit _owner)
    {
        owner = _owner;
        for(int i = 0; i < toDo.Count; i++)
        {
            toDo[i].Take(_owner);
        }
        owner.actions.AddRange(toDo);
    }
    public void Take(Unit _owner,Vector3[] path)
    {
        MonoBehaviour.print("zabralem");
        owner = _owner;
        Go temp = new Go(owner, path);
        temp.Take(owner);
        owner.actions.Add(temp);
        for (int i = 0; i < toDo.Count; i++)
        {
            toDo[i].Take(_owner);
        }
        owner.actions.AddRange(toDo);
    }
}
