﻿using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        Application.Quit();
    }
}
//using UnityEngine;
//using System.Collections;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class MouseManager : MonoBehaviour
//{

//    Rigidbody2D grabbedObject = null;
//    public Text countFrac;

//    void Update()
//    {
//        countFrac.text = Master.cut_frac;
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            // We clicked, but on what?
//            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
//            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

//            Vector2 dir = Vector2.zero;

//            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
//            if (hit != null && hit.collider != null)
//            {
//                // We clicked on SOMETHING that has a collider & rigidbody
//                if (hit.collider.GetComponent<Rigidbody2D>() != null)
//                {
//                    grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
//                }
//            }
//        }

//        if (Input.GetTouch(0).phase == TouchPhase.Ended)
//        {
//            grabbedObject = null;
//        }

//        if (Master.is_cut == true)
//        {

//            //SceneManager.UnloadSceneAsync("scenes/cut");
//        }

//    }

//    void FixedUpdate()
//    {
//        if (grabbedObject != null)
//        {
//            // Move the object with the mouse
//            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
//            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
//            grabbedObject.position = mousePos2D;
//        }
//    }

//}
