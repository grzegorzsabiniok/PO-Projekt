using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour,IInfo {
    public Transform windowPrefab;
    public string useAnimation;
    public float timeAnimation;
    public void Show()
    {
        Transform temp = Transform.Instantiate(windowPrefab);
        temp.GetComponent<Window>().title.text = name;
       
        temp.GetComponent<Window>().target = transform;
        temp.SetParent(GameObject.Find("Canvas").transform);
        temp.localPosition = new Vector3(0, 0, 0);
    }
    public void Hide()
    {

    }
    public string name;
    public Vector3[] grid;
    public Vector3[] fundations;
    public Transform interaction;
    // Use this for initialization
    public bool CanPlace()
    {
        for (int i = 0; i < grid.Length; i += 2)
        {
            for (float x = grid[i].x; x < grid[i+1].x; x++)
            {
                for (float y = grid[i].y; y < grid[i+1].y; y++)
                {
                    for (float z = grid[i].z; z < grid[i+1].z; z++)
                    {
                        if (Main.main.GetBlock(transform.position + new Vector3(x, y, z)) != 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        if(fundations.Length>0)
        for (float x = fundations[0].x; x < fundations[1].x; x++)
        {
            for (float y = fundations[0].y; y < fundations[1].y; y++)
            {
                for (float z = fundations[0].z; z < fundations[1].z; z++)
                {
                    if (Main.main.GetBlock(transform.position + new Vector3(x, y, z)) == 0)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    public void ModifyColiders(int _x)
    {
        for (int i = 0; i < grid.Length; i += 2)
        {
            for (float x = grid[i].x; x < grid[i+ 1].x; x++)
            {
                for (float y = grid[i].y; y < grid[i+ 1].y; y++)
                {
                    for (float z = grid[i].z; z < grid[i+ 1].z; z++)
                    {
                        Main.main.SetBlock(transform.position + new Vector3(x, y, z), _x);
                    }
                }
            }
        }
    }
    public virtual void GenerateColiders()
    {
        ModifyColiders(-1);
    }
    public void DeleteColiders()
    {
        ModifyColiders(0);
    }
    void Start () {
        GenerateColiders();
	}
    
void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
        for (int i = 0; i < grid.Length; i += 2)
        {
            for (float x = grid[i].x; x < grid[i + 1].x; x++)
            {
                for (float y = grid[i].y; y < grid[i + 1].y; y++)
                {
                    for (float z = grid[i].z; z < grid[i + 1].z; z++)
                    {
                        Gizmos.DrawCube(transform.position + new Vector3(x, y+0.5f, z), new Vector3(1, 1, 1));
                    }
                }
            }
        }
        Gizmos.color = Color.blue;
        if (fundations.Length > 0)
            for (float x = fundations[0].x; x < fundations[1].x; x++)
        {
            for (float y = fundations[0].y; y < fundations[1].y; y++)
            {
                for (float z = fundations[0].z; z < fundations[1].z; z++)
                {
                    Gizmos.DrawCube(transform.position + new Vector3(x, y + 0.5f, z), new Vector3(1, 1, 1));
                }
            }
        }
    }

    // Update is called once per frame
    public virtual void Use(Unit _user)
    {

    }
}
