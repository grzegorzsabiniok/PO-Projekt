using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour {

    //Transforms
    public Transform topRenderUi;
    public Slider slider;

	void Start () {
        topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
        slider.value = Main.main.topRender;
        slider.maxValue = Main.main.chunkSize.y-1;
	}
	public void TerrainRenderUp()
    {
        TerrainRender(1);
    }
    public void TerrainRender()
    {
        Main.main.topRender = (int)slider.value;
        Chunk[] temp = Main.main.GetAllChunks();
        //temp[0].Slice();

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].sliced = true;
        }

        topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
    }
    public void TerrainRenderDown()
    {
        //TerrainRender(-1);

        Main.main.topRender--;
        Chunk[] temp = Main.main.GetAllChunks();
        //temp[0].Slice();
        
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].sliced = true;
        }
        
        topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
    }
    void TerrainRender(int _x)
    {
        if (Main.main.topRender + _x < Main.main.chunkSize.y && Main.main.topRender + _x > 0)
        {
            Main.main.topRender += _x;
            Chunk[] temp = Main.main.GetAllChunks();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Render();
                //temp[i].RenderWater();
            }
            topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
        }
    }

}
