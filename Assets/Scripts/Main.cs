using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public static Main main;
    [Header("Map Settings")]
    public Vector3 chunkSize = new Vector3(16, 64, 16);
    public int mapSeed=0;
    public Vector3 mapSize;
    public float mapAmplitude = 50f;
    public int mapCubature;
    public int mapHeight;
    public int mapLevelsCount;
    public int mapLevelHeight;
    public int waterLevel;
    public float treeDensity;
    public Dictionary<Vector2, Chunk> chunks = new Dictionary<Vector2, Chunk>();
    [Header("Game Settings")]
    public float unitSpeed;
    [Header("Viev Settings")]
    public int topRender=32;
    /// <summary>
    int[,,] map;
    //0-air
    //-1 collider
    //-2 - ladder
    //-3 - stockpile
    //-100 - interest point
    /// </summary>
    public List<POI> poi = new List<POI>();
    void Awake () {
        main = this;
        map = new int[(int)(chunkSize.x * mapSize.x), (int)(chunkSize.y * mapSize.y), (int)(chunkSize.z * mapSize.z)];
        Generate();
	}

    public void AddPOI(POI _poi)
    {
        poi.Add(_poi);
    }
    public POI CheckPOI(Vector3 _position, Unit _owner, POI.Type _type)
    {
        _position = Normalize(_position);
        for(int i = 0; i < poi.Count; i++)
        {
            if(poi[i].position == _position && poi[i].Match(_owner, _type))
            {
                return poi[i];
            }
        }
        return null;
    }

    public void Generate()
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {

            for (int z = 0; z < map.GetLength(2); z++)
            {
                int t = 0;
                for (int i = 0; i < GetMapHeight(x, z); i++)
                {
                    map[x, i, z] = (int)Chunk.Material.stone;
                    t = i;
                }
                if (t < waterLevel)
                {
                    map[x, t - 1, z] = (int)Chunk.Material.sand;
                    for (int i = t; i < waterLevel; i++)
                    {
                        map[x, i, z] = (int)Chunk.Material.water;
                    }
                }
                else {
                    map[x, t, z] = (int)Chunk.Material.grass;
                }
            }
        }
    }
    public Vector3 GetMapSize()
    {
        return new Vector3(chunkSize.x * mapSize.x, chunkSize.y * mapSize.y, chunkSize.z * mapSize.z);
    }
    public Chunk[] GetAllChunks()
    {
        Chunk[] temp = new Chunk[chunks.Count];
        chunks.Values.CopyTo(temp, 0);
        return temp;
    }
    public Chunk GetChunk(Vector3 _position)
    {
        if (chunks.ContainsKey(new Vector2((int)(_position.x) / (int)(chunkSize.x), (int)(_position.z) / (int)(chunkSize.z))))
            return chunks[new Vector2((int)(_position.x) / (int)(chunkSize.x), (int)(_position.z) / (int)(chunkSize.z))];
        else return null;
    }
    public int GetBlock(int x,int y,int z)
    {
        if (x < 0 || y < 0 || z < 0 || x > GetMapSize().x - 1 || y > GetMapSize().y - 1 || z > GetMapSize().z - 1) return -10;
        return map[x, y, z];
    }
    public int GetBlock(Vector3 _position)
    {
        return GetBlock((int)Mathf.Floor(_position.x), (int)Mathf.Floor(_position.y), (int)Mathf.Floor(_position.z));
    }
    public void SetBlock(Vector3 _position,int _block)
    {
        map[(int)_position.x, (int)_position.y, (int)_position.z] = _block;
        if(_block > -1)
        {
            GetChunk(_position).Actualize();
        }
    }
    public int GetTreeRange()
    {
        return (int)(chunkSize.x * mapSize.x - 10);
    }
    public bool GetTreePosition(int _x,int _y)
    {
        
        if (Mathf.PerlinNoise(_x/15f+mapSeed+666, _y/15f+mapSeed+666) > treeDensity && GetMapHeight(_x, _y) > waterLevel)
        {
            return true;
        }
        else {
            return false;
        }

    }
    public int GetMapHeight(int _x,int _y)
    {
        return (int)(Mathf.PerlinNoise((_x/ mapCubature) * mapCubature / mapAmplitude + mapSeed, (_y/ mapCubature) * mapCubature / mapAmplitude + mapSeed)*mapLevelsCount)*mapLevelHeight+mapHeight;
    }
    public static Vector3 Normalize(Vector3 _vec)
    {
        return new Vector3(Mathf.Round(_vec.x), Mathf.Round(_vec.y), Mathf.Round(_vec.z));
    }
}
