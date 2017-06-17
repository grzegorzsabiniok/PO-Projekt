using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Unit : MonoBehaviour, IInfo {
    //public Vector3[] foots = new Vector3[100000];
    public ItemPatern axe,shield;
    public Sprite portrait;
    public Transform windowPrefab;
    public string species;
    public List<Action> actions = new List<Action>();
    public List<Task> tasks = new List<Task>();
    public float speed = 1;
    // info
    public string infoTitle, infoDesc;
    bool searching = false;

    //equipment
    public Item[] items = new Item[5];
    
    public void AddItem(Item _item)
    {
        if (_item.patern.size == 0)
        {
            for (int i = 1; i < 5; i++)
            {
                if (items[i] == null)
                {
                    items[i] = _item;
                    items[i].patern.Put(items[i], this);
                    break;
                }
            }
        }
        else
        {
            items[0] = _item;
                items[0].patern.Put(items[0], this);
        }
    }
    public int CheckItem(ItemPatern _patern)
    {
        int temp = -1;
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            if(items[i].patern == _patern)
            {
                temp = i;
            }
        }
        return temp;
    }
    public void UseItem(ItemPatern _patern)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
                if (items[i].patern == _patern)
                {
                    items[i].patern.Use(items[i], this);
                    return;
                }
        }
    }
    public void ItemToBackpack()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                items[i].patern.ToBackpack(items[i], this);
            }
        }
    }
    public void DropItem()
    {
        items[0].patern.Drop(transform.position,items[0]);
        Destroy(items[0].mesh.gameObject);
        items[0] = null;
    }
    void Start() { 
        print("start");
        AddItem(new Item(axe));
        AddItem(new Item(shield));
        //DropItem();

    }
    public void Show()
    {
        Transform temp = Transform.Instantiate(windowPrefab);
        temp.GetComponent<Window>().title.text = infoTitle;
        temp.GetComponent<Window>().desc.text = infoDesc;
        temp.parent = GameObject.Find("Canvas").transform;
        print("ok");
    }
    public void Hide()
    {

    }
	void Update () {

        /*
        if (actions.Count > 0)
        {
            if (!actions[0].Act())
            {
                actions.RemoveAt(0);
            }
        }
        */
        if (tasks.Count >0)
        {
            if (!tasks[0].Act())
            {
                tasks.RemoveAt(0);
            }
        }
        else
        {
            if (Main.main.poi.Count > 0)
            {
                print("niech rozpocznie sie szukanie");
                Task temp = new Task(new Action[]
                {
                new Search(POI.Type.work)

                });
                temp.Take(this);
            }
                /*
            if (Willage.willage.tasks.Count() > 0)
            {
                if (!searching)
                {
                    StartSearchJob();
                    searching = true;
                }
                Vector3[] temp = Search(-100);
                if (temp != null)
                {
                    Task temp2 = Willage.willage.GetTask(temp[0]);
                    if (temp2 != null)
                    {

                        temp2.Take(this, temp);
                    }
                }
            }
            else
            {
                searching = false;
            }
            */
        }
    }
    public void SetAnimation(string _name)
    {
        
        string[] names = new string[]
        {
            "idle",
            "walk",
            "chop"            
        };
        GetComponent<Animator>().SetBool("empty",items[0] == null); 
        for(int i=0;i<names.Length;i++)
            if (names[i] == _name)
            {
                GetComponent<Animator>().SetInteger("main", i);
                break;
            }
    }
    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.white;
        foreach (Vector3 i in foots.Keys)
        {
            Gizmos.color = Color.white;
            if (i == foots.Keys.ElementAt(firstIndex))
                Gizmos.color = Color.red;
            Gizmos.DrawSphere(i, 0.5f);
        }
           

    }
    int lastIndex = 0, firstIndex = 0;
    Dictionary<Vector3, Vector3> foots = new Dictionary<Vector3, Vector3>();
    void StartSearchJob()
    {
        lastIndex = 0;
        firstIndex = 0;
        foots.Clear();
        foots.Add(transform.position, new Vector3(-1,-1,-1));
    }

    Vector3[] Search(int _target)
    {
        Vector3 curent;
        for (int i = 0; i < 10; i++)
        {
            if (firstIndex >= foots.Count)
            {
                print("nie znalazlem :(");
                searching = false;
                return null;
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

                        if (!foots.ContainsKey(temp)&& Go.CanGo(temp))
                        {
                            foots.Add(temp, curent);
                            if (Main.main.GetBlock(temp) == _target)
                            {
                                //Task temp2 = Willage.willage.GetTask(temp);
                               // if (temp2 != null)
                                //{
                                 //   searching = false;
                                    List<Vector3> path = new List<Vector3>();
                                    Vector3 t3=temp;
                                    while(foots[t3] != new Vector3(-1, -1, -1))
                                    {
                                        path.Add(t3);
                                        t3 = foots[t3];
                                    }
                                   // temp2.Take(this,path.ToArray());
                                    return path.ToArray();
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }
        
    
}
