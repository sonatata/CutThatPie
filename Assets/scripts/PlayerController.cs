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
    // Use this for initialization
    void Start () {
        TrailRenderer tr = this.GetComponent<TrailRenderer>() ;
        tr.sortingLayerName = "foreground";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grabObject != null)
        {
            // Move the object with the mouse
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
            grabObject.position = mousePos2D;
        }

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

    }


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

        if (Master.is_cut == true)
        {
            //SceneManager.UnloadScene("_Scenes/minigame");
        }

    }

    //void FixedUpdate()
    //{
    //    if (grabObject != null)
    //    {
    //        // Move the object with the mouse
    //        Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
    //        grabObject.position = mousePos2D;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            if (chkpts == 1)
            {
                if (other.name == "1/2")
                {

                    Instantiate(half, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                    //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                    //Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                    //flag = true;
                }
                if (other.name == "1/4")
                {
                    Instantiate(qrtr, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                    //flag = true;
                }
                if (other.name == "1/8")
                {
                    Instantiate(eth, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                    //flag = true;
                }
                // do something with master //hlf
                //Master.cut_frac = other.gameObject.name;
                //Master.is_cut = true;
                //Destroy(go);
            }
            chkpts += 1;
        }

        else
        {

        }

    }
}
