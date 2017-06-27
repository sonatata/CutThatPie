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
    private bool dragging = false;
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
        if (other.gameObject.CompareTag("invisible"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (other.gameObject.CompareTag("checkpoint"))
        {
            if (chkpts == 1)
            {
                if (other.name == "1/2")
                {
                    Destroy(go);
                    //Instantiate(half, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                    Instantiate(half, new Vector2(-6.1f,-2.8f ), Quaternion.identity);
                    //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                    //Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                    //flag = true;
                }
                if (other.name == "1/4")
                {
                    Destroy(go);
                    Instantiate(qrtr, new Vector2(-6.1f, -2.8f), Quaternion.identity);
                    //flag = true;
                }
                if (other.name == "1/8")
                {
                    Destroy(go);
                    Instantiate(eth, new Vector2(-6.1f, -2.8f), Quaternion.identity);
                    //flag = true;
                }
                // do something with master //hlf
                //Master.cut_frac = other.gameObject.name;
                //Master.is_cut = true;

            }
            chkpts += 1;
        }
        
        else
        {

        }

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





