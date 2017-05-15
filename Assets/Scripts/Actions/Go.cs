using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Go : Action {
    Vector3[] path = new Vector3[0];
    int pathPosition = 0;
    Vector3 target;
    public Go(Unit _owner,Vector3 _target)
    {
        name = "Go";
        owner = _owner;
        //owner.Go(_target);
        target = _target;
    }
    public Go(Unit _owner, Vector3[] _path)
    {
        name = "Go";
        owner = _owner;
        //owner.Go(_target);
        path = _path;
        pathPosition = path.Length - 1;
    }
    public Go( Vector3 _target)
    {
        target = _target;
        name = "Go";
    }
    public override void Start()
    {
        if (pathPosition == 0) { 
        SetPath(target);
        pathPosition = path.Length - 1;
    }
        owner.SetAnimation("walk");
        
    }
    public override bool Success()
    {
        if(owner.transform.position == target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override bool Update()
    {
        if (pathPosition > -1)
        {
            if (CanGo(path[pathPosition]))
            {
                owner.transform.LookAt(path[pathPosition]);
                owner.transform.localEulerAngles = new Vector3(0, owner.transform.localEulerAngles.y, 0);
                owner.transform.position = Vector3.MoveTowards(owner.transform.position, path[pathPosition], owner.speed * Time.deltaTime * 2 * Main.main.unitSpeed);
                if (Vector3.Distance(owner.transform.position, path[pathPosition]) < 0.01f)
                {
                    owner.transform.position = path[pathPosition];
                    pathPosition--;
                    
                }
            }
            else
            {
                SetPath(path[0]);
                pathPosition = path.Length - 1;
            }
        }
        else
        {
            owner.SetAnimation("idle");
            return false;
        }
        return true;
    }
    struct Waypoint
    {
        public Waypoint(float _value, Vector3 _parent)
        {
            value = _value;
            parent = _parent;
            used = false;
        }
        public float value;
        public Vector3 parent;
        public bool used;
    };
    void SetPath(Vector3 _target)
    {
        _target = new Vector3(Mathf.Floor(_target.x), Mathf.Floor(_target.y), Mathf.Floor(_target.z));
        Dictionary<Vector3, Waypoint> waypoint = new Dictionary<Vector3, Waypoint>();
        Vector3 curent;
        curent = new Vector3( Mathf.Floor(owner.transform.position.x), Mathf.Floor(owner.transform.position.y), Mathf.Floor(owner.transform.position.z));
        waypoint.Add(curent, new Waypoint(10000, Vector3.zero));
        for (int i = 0; i < 2000; i++)
        {
            for (int z = 0; z < 3; z++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        
                        if (curent == _target)
                        {
                            Vector3 temp3 = curent;
                            List<Vector3> temp2 = new List<Vector3>();
                            temp2.Add(curent);
                            while (waypoint[temp3].parent != Vector3.zero)
                            {

                                temp2.Add(temp3);
                                temp3 = waypoint[temp3].parent;

                            }
                            path = temp2.ToArray();
                            MonoBehaviour.print(waypoint.Count+"|"+i);
                            return;
                        }
                        Vector3 temp = curent + new Vector3(x - 1, y - 1, z - 1);
                        if (!waypoint.ContainsKey(temp) && CanGo(temp))
                        {

                            waypoint.Add(temp, new Waypoint(Vector3.Distance(temp, _target)+ Vector3.Distance(temp, owner.transform.position), curent));
                            //waypoint.Add(temp, new Waypoint(Vector3.Distance(temp, _target) + Vector3.Distance(temp, curent)+waypoint[curent].value, curent));

                        }
                    }
                }
            }
            Waypoint t = waypoint[curent];
            t.used = true;
            waypoint[curent] = t;
            curent = waypoint.Aggregate((l, r) => ((l.Value.value > r.Value.value && !r.Value.used) || l.Value.used) ? r : l).Key;
            
        }


    }
    public static bool CanGo(Vector3 _position)
    {
        if ((Main.main.GetBlock(_position) == 0 || Main.main.GetBlock(_position) == -2 || Main.main.GetBlock(_position) == -100)
            && (Main.main.GetBlock(_position - new Vector3(0, 1, 0)) != 0 || Main.main.GetBlock(_position - new Vector3(0, 1, 0)) == -2)
            && Main.main.GetBlock(_position - new Vector3(0, 1, 0)) != 1//zakomentuj zeby wlaczyc jezus_mode
            && (Main.main.GetBlock(_position + new Vector3(0, 1, 0)) == 0 || Main.main.GetBlock(_position + new Vector3(0, 1, 0)) == -2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
