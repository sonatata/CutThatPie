using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{

    private float dist;
    private bool dragging = false;
    //private Vector3 offset;
    private Transform toDrag;
    Vector3 v3;


    public Vector3 GOcenter;
    public Vector3 touchPosition;
    public Vector3 offset;
    public Vector3 newGOCenter;

    public GameObject gameObjectToDrag;

    RaycastHit hit;

    public bool draggingMode = false;


    Rigidbody2D grabbedObject = null;
    public Text countFrac;

    void Update()
    {
        //if (Input.touchCount != 1)
        //{
        //    dragging = false;
        //    return;
        //}

        //Touch touch = Input.touches[0];
        ////Vector2 pos = touch.position;
        //Vector3 pos = Input.mousePosition;
        //if (touch.phase == TouchPhase.Began)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(pos);
        //    RaycastHit2D hitt = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero); ;
        //    if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
        //    {
        //        Debug.Log("Here");
        //        toDrag = hit.transform;
        //        dist = hit.transform.position.z - Camera.main.transform.position.z;
        //        v3 = new Vector3(pos.x, pos.y, dist);
        //        //v3 = new Vector3(pos.x, pos.y, 0);
        //        v3 = Camera.main.ScreenToWorldPoint(v3);
        //        offset = toDrag.position - v3;
        //        dragging = true;
        //    }
        //}
        //if (dragging && touch.phase == TouchPhase.Moved)
        //{
        //    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        //    //v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //    v3 = Camera.main.ScreenToWorldPoint(v3);
        //    toDrag.position = v3 + offset;
        //}
        //if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        //{
        //    dragging = false;
        //}

        //if (Input.GetMouseButtonDown(0))
        //{

        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);



        //    if (Physics.Raycast(ray, out hit))
        //    {

        //        gameObjectToDrag = hit.collider.gameObject;
        //        GOcenter = gameObjectToDrag.transform.position;
        //        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        offset = touchPosition - GOcenter;
        //        draggingMode = true;

        //    }


        //    if (hit2d)
        //    {

        //        gameObjectToDrag = hit2d.collider.gameObject;
        //        GOcenter = gameObjectToDrag.transform.position;
        //        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        offset = touchPosition - GOcenter;
        //        draggingMode = true;

        //    }




        //}
        countFrac.text = Master.cut_frac;
        if (Input.GetMouseButtonDown(0))
        {
            // We clicked, but on what?
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

            Vector2 dir = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
            if (hit != null && hit.collider != null)
            {
                // We clicked on SOMETHING that has a collider
                if (hit.collider.GetComponent<Rigidbody2D>() != null)
                {
                    grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }

        if (Master.is_cut == true)
        {
            //SceneManager.UnloadScene("_Scenes/minigame");
        }

    }

    void FixedUpdate()
    {
        if (grabbedObject != null)
        {
            // Move the object with the mouse
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
            grabbedObject.position = mousePos2D;
        }
    }

}
