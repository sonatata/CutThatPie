using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slice_script : MonoBehaviour {

    Vector3 mouseStartPosition;
    bool mousePressed;
    public GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (!mousePressed)
            {
                mouseStartPosition = currentMousePosition;
            }

            Debug.DrawLine(mouseStartPosition, currentMousePosition, Color.red);
            mousePressed = true;
        } else if(mousePressed)
        {
            SpriteSlicer2D.SliceSprite(mouseStartPosition, currentMousePosition, go);
            mousePressed = false;
        }
	}
}
