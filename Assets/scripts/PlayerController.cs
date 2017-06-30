using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float speed = 3.0f;
    public GameObject go;
    int chkpts = 0;
    Rigidbody2D grabObject = null;
    public GameObject half;
    public GameObject qrtr;
    public GameObject eth;
    public GameObject plate;
    public GameObject roundPiePrefab;
    public GameObject roundPiePrefabcpy;
    public GameObject knife;
    private GameObject gg;
    private GameObject ggp;
    public CutController script;

    private float dist;
    //private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    Vector3 v3;

    //bool flag = false;
    public static int count = 0;

    // Use this for initialization
    void Start() {
        TrailRenderer tr = this.GetComponent<TrailRenderer>();
        tr.sortingLayerName = "foreground";

        script = GetComponent<CutController>();


        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
    }


    void Update()
    {
        //countFrac.text = Master.cut_frac;
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
                    grabObject = hit.collider.GetComponent<Rigidbody2D>();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            grabObject = null;
        }

    }

    void FixedUpdate()
    {
        if (grabObject != null)
        {
            // Move the object with the mouse
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
            grabObject.position = mousePos2D;
        }
    }

}





