using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour {
    public Transform topRenderUi;
    public Slider slider;

	void Start () {
        topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
        slider.value = Main.main.topRender;
        slider.maxValue = Main.main.chunkSize.y-1;
	}
    public void TerrainRender()
    {
        Main.main.topRender = (int)slider.value;
        Chunk[] temp = Main.main.GetAllChunks();
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].sliced = true;
        }
        topRenderUi.GetComponent<Text>().text = Main.main.topRender.ToString();
    }
    public void Stockpile()
    {

    }

}
