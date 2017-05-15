using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPatern : MonoBehaviour {
    public string name;
    public int size;
    public Sprite icon;
    public string target;
    //onGround
    public Vector3 positionOnGround;
    public Vector3 rotationOnGround;
    public Vector3 scaleOnGround;
    //inHand
    public Vector3 positionInHand;
    public Vector3 rotationInHand;
    public Vector3 scaleInHand;
    //inBackpack
    public Vector3 positionInBackpack;
    public Vector3 rotationInBackpack;
    public Vector3 scaleInBackpack;
    public string InBackpack;

    public void Drop(Vector3 _position,Item _item)
    {
        print("wyrzucam");
        Transform temp = Instantiate(transform);
        temp.position = _position+positionOnGround;
        temp.eulerAngles = rotationOnGround;
        temp.localScale = scaleOnGround;
        Destroy(temp.GetComponent<ItemPatern>());
        temp.gameObject.AddComponent<ItemContainer>();
        temp.GetComponent<ItemContainer>().item = _item;
    }
    public void Put(Item _item,Unit _unit)
    {
        Transform temp = Instantiate(transform);
        temp.SetParent(_unit.transform.Find(InBackpack));
        temp.localPosition = positionInBackpack;
        temp.localEulerAngles = rotationInBackpack;
        temp.localScale = scaleInBackpack;
        _item.mesh = temp;

    }
}
