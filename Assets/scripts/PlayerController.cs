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

    bool flag = false;
    public static int count = 0;

    // Use this for initialization
    void Start() {
        TrailRenderer tr = this.GetComponent<TrailRenderer>();
        tr.sortingLayerName = "foreground";

        script = GetComponent<CutController>();

        
    }

    // Update is called once per frame
    //void Update()
    //{
        //ggp = script.instance;
        //if (flag)
        //{

        //    //Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);
        //}
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

        //    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        //    {
        //        // get the touch position from the screen touch to world point
        //        Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
        //        // lerp and set the position of the current object to that of the touch, but smoothly over time.
        //        transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
        //    }
        //}

        //if (Input.touchCount != 1)
        //{
        //    dragging = false;
        //    return;
        //}

        //Touch touch = Input.touches[0];
        //Vector3 pos = touch.position;

        //if (touch.phase == TouchPhase.Began)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(pos);
        //    if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
        //    {
        //        Debug.Log("Here");
        //        toDrag = hit.transform;
        //        dist = hit.transform.position.z - Camera.main.transform.position.z;
        //        v3 = new Vector3(pos.x, pos.y, dist);
        //        v3 = Camera.main.ScreenToWorldPoint(v3);
        //        offset = toDrag.position - v3;
        //        dragging = true;
        //    }
        //}
        //if (dragging && touch.phase == TouchPhase.Moved)
        //{
        //    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        //    v3 = Camera.main.ScreenToWorldPoint(v3);
        //    toDrag.position = v3 + offset;
        //}
        //if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        //{
        //    dragging = false;
        //}
   // }

    private void OnTriggerEnter2D(Collider2D other)
    {
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

        //if (other.gameObject.CompareTag("wall"))
        //{
        //    if (!flag)
        //    {
        //        if(count == 0)
        //        {
        //            Destroy(ggp);
        //            gg = Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);
        //            count += 1;
        //        }
        //        if (count % 2 == 0 && count != 0)
        //        {
        //            //Destroy(go);
        //            Destroy(gg);
        //            //Destroy(this);
        //            //gg = Resources.Load("round_pie_cut") as GameObject;
        //            //gg.transform.position = new Vector2(0, 0);
        //            gg = Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);
        //            //gameObject.Find("instance").GetComponent
                    
        //            count += 1;
        //            //Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);

        //        }
        //        if (count % 2 == 1)
        //        {
        //            //Destroy(go);
        //            Destroy(gg);
        //            //Destroy(this);
        //            gg = Instantiate(roundPiePrefabcpy, new Vector2(0, 0), Quaternion.identity);
        //            count += 1;
        //        }
        //        flag = true;
        //    }


            //if (flag = 1)
            //{
            //    Destroy(go);
            //    //Destroy(this);
            //    Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);
            //    flag += 1; ;
            //}
        
        else
        {

        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.name)


    //}


    //if (grabObject != null)
    //{
    //    // Move the object with the mouse


    //    if (flag)
    //    {

    //        //countFrac.text = Master.cut_frac;
    //        if (Input.GetTouch(0))
    //        {
    //            // We clicked, but on what?
    //            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

    //            Vector2 dir = Vector2.zero;

    //            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
    //            if (hit != null && hit.collider != null)
    //            {
    //                // We clicked on SOMETHING that has a collider
    //                if (hit.collider.GetComponent<Rigidbody2D>() != null)
    //                {
    //                    grabObject = hit.collider.GetComponent<Rigidbody2D>();
    //                    grabObject.position = mousePos2D;
    //                }
    //            }
    //        }

    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            grabObject = null;
    //        }

    //        Debug.Log("IM HERE");
    //        //Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        //Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

    //    } 


    //if (Input.GetKey(KeyCode.LeftArrow))
    //{
    //    transform.position += Vector3.left * speed * Time.deltaTime;
    //}
    //if (Input.GetKey(KeyCode.RightArrow))
    //{
    //    transform.position += Vector3.right * speed * Time.deltaTime;
    //}
    //if (Input.GetKey(KeyCode.UpArrow))
    //{
    //    transform.position += Vector3.up * speed * Time.deltaTime;
    //}
    //if (Input.GetKey(KeyCode.DownArrow))
    //{
    //    transform.position += Vector3.down * speed * Time.deltaTime;
    //}




    //public Text countFrac;

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



    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    flag = false;
    //    Debug.Log("false");
    //}

}





