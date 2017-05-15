using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour {
    public float cameraSpeed;
    Vector3 mouse;
    float touchpad;

	void Update () {
        transform.parent.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse ScrollWheel")*3 + touchpad, Input.GetAxis("Vertical"))*cameraSpeed);
        if (Input.GetMouseButton(1))
        {
            Vector3 temp = mouse - Input.mousePosition;
            transform.Rotate(new Vector3(transform.localEulerAngles.x+temp.y < 60 && transform.localEulerAngles.x + temp.y >5?temp.y:0,0,0));
            transform.parent.Rotate(new Vector3(0, -temp.x, 0));
        }
        mouse = Input.mousePosition;
    }
    public void OnGUI()
    {
        if (Event.current.type == EventType.ScrollWheel)
        {
            touchpad = Event.current.delta.y;
        }
        else
        {
            touchpad = 0;
        }
    }
}
