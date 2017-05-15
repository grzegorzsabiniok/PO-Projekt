using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInfo
{
    void Show();
    void Hide();
}

class Info : MonoBehaviour
{
    public IInfo target;
    public Transform unitWindowPrefab;
    public Transform canvas;
    void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
             RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin,ray.direction,out hit))
            {

                if (hit.transform.GetComponent<IInfo>() != null) { 
                
                    target = hit.transform.GetComponent<IInfo>();
                    target.Show();
                    print(hit.collider.transform.name);
                }
            }
        }
    }
}
