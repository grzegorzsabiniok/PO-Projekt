using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Search : Action {
    int lastIndex = 0, firstIndex = 0;
    Dictionary<Vector3, Vector3> foots = new Dictionary<Vector3, Vector3>();
    int target;
    Go go;
    public Search(Go _go, int _target)
    {
        target = _target;
        go = _go;
    }
    public override void Start()
    {
        lastIndex = 0;
        firstIndex = 0;
        foots.Clear();
        foots.Add(task.owner.transform.position, new Vector3(-1, -1, -1));
    }
    public override bool Update()
    {
        
        Vector3 curent;
        for (int i = 0; i < 10; i++)
        {
            if (firstIndex >= foots.Count)
            {
                return false;
            }
            curent = foots.Keys.ElementAt(firstIndex);
            firstIndex++;

            for (int z = 0; z < 3; z++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        Vector3 temp = curent + new Vector3(x - 1, y - 1, z - 1);

                        if (!foots.ContainsKey(temp) && Go.CanGo(temp))
                        {
                            foots.Add(temp, curent);
                            if (Main.main.GetBlock(temp) == target)
                            {
                                //Task temp2 = Willage.willage.GetTask(temp);
                                // if (temp2 != null)
                                //{
                                //   searching = false;
                                List<Vector3> path = new List<Vector3>();
                                Vector3 t3 = temp;
                                while (foots[t3] != new Vector3(-1, -1, -1))
                                {
                                    path.Add(t3);
                                    t3 = foots[t3];
                                }
                                // temp2.Take(this,path.ToArray());
                                go.path = path.ToArray();

                                MonoBehaviour.print("foots" + foots.Count);
                                return false;
                            }
                        }
                    }
                }
            }
        }
        return true;
    }

}
