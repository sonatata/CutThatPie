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

    public bool tut;
    public bool flag;


    Rigidbody2D grabbedObject = null;
    public Text countFrac;

    void Start()
    {
        flag = false;

    }

    public void changebool()
    {
        flag = true;
    }

    void Update()
    {
        
        //countFrac.text = Master.cut_frac;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //// We clicked, but on what?
        //    //Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    //Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

        //    //Vector2 dir = Vector2.zero;

        //    //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
        //    //if (hit != null && hit.collider != null)
        //    //{
        //    //    // We clicked on SOMETHING that has a collider
        //    //    if (hit.collider.GetComponent<Rigidbody2D>() != null)
        //    //    {
        //    //        grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
        //    //    }
        //    //}
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    grabbedObject = null;
        //}

        //if (Master.is_cut == true)
        //{
        //    //SceneManager.UnloadScene("_Scenes/minigame");
        //}

    }

    //IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    obj.SetActive(false);
    //}

    void FixedUpdate()
    {
        //if (grabbedObject != null)
        //{
        //    // Move the object with the mouse
        //    Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
        //    grabbedObject.position = mousePos2D;

        //    if (arrow1 != null && grabbedObject.CompareTag("whole"))
        //    {
        //        Destroy(arrow1);
        //        arrow2.SetActive(true);
        //        StartCoroutine(RemoveAfterSeconds(3, arrow2));

                
        //        flag = true;
        //    }

        //    if (flag)
        //    {

        //    }
        //}
    }

}
