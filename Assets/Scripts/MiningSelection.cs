using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSelection : Selection {
    public override void DoThings()
    {
        Vector3 min = new Vector3(Mathf.Min(start.x, end.x), Mathf.Min(start.y, end.y), Mathf.Min(start.z, end.z));
        Vector3 max = new Vector3(Mathf.Max(start.x, end.x), Mathf.Max(start.y, end.y), Mathf.Max(start.z, end.z));
        for (int x = (int)min.x; x <= (int)max.x; x++)
        {
            for (int y = (int)min.y; y <= (int)max.y; y++)
            {
                for (int z = (int)min.z; z <= (int)max.z; z++)
                {
                    Main.main.SetBlock(new Vector3(x, y, z), 0);
                }
            }
        }
        Destroy(gameObject);
    }
    public override bool CanPlace(Vector3 start, Vector3 end)
    {
        return true;
    }
}
