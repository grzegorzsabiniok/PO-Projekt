using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour {

    public Transform prefab;
    Dictionary<Vector3, Item> slots = new Dictionary<Vector3, Item>();
    public void AddSlots(Vector3 start, Vector3 end)
    {
        Vector3 min = new Vector3(Mathf.Min(start.x, end.x), 0, Mathf.Min(start.z, end.z));
        Vector3 max = new Vector3(Mathf.Max(start.x, end.x), 0, Mathf.Max(start.z, end.z));
        for (int x = (int)min.x; x <= (int)max.x; x++)
        {
            for (int y = (int)min.z; y <= (int)max.z; y++)
            {
                slots.Add(new Vector3(x, start.y, y), null);
                Main.main.SetBlock(new Vector3(x, start.y, y), -3);
            }
        }
        Show();
    }
    public void Show()
    {
        foreach(Vector3 i in slots.Keys)
        {
            Transform temp = Transform.Instantiate(prefab);
            temp.position = i;

        }
    }
}
