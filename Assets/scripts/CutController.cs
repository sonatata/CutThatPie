using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutController : MonoBehaviour {

    //public GameObject half;
    //public GameObject qrtr;
    //public GameObject eth;
    public GameObject roundPiePrefab;
    public GameObject fullpie;
    public GameObject instance;
    bool flag = false;
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
                                //public GameObject tool_location;
                                // Use this for initialization

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        //_centre = transform.position;
    }
    void OnMouseDown()
    {
        //transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        //Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);
    }

    private void Update()
    {
        //_angle += RotateSpeed * Time.deltaTime;

        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        //transform.position = _centre + offset;

        //transform.position.x = 0;
        //transform.position.x = Mathf.Sin(Time.time * speed);
        //transform.position = transform.position + new Vector3(0, Mathf.Sin(Time.time * speed), 0);
    }
    // Update is called once per frame
    void FixedUpdate () {

        if (!flag)
        {
            //if (Master.cut_frac == "1/2")
            //{

            //    Instantiate(half, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
            //    //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
            //    //Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            //    flag = true;
            //}
            //if(Master.cut_frac == "1/4")
            //{
            //    Instantiate(qrtr, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
            //    flag = true;
            //}
            //if (Master.cut_frac == "1/8")
            //{
            //    Instantiate(eth, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
            //    flag = true;
            //}

        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("cuttingBoard"))
        {

            //creates a pie module to cut on 
            Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);

            //Application.LoadLevel("_Scenes/minigame");
            //SceneManager.LoadScene ("cut", LoadSceneMode.Additive);

            //destroys pie colliding with knife 
            Destroy(this.gameObject);
            //Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
            


            //Instantiate(result, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity, plate.transform);
        }


    }
}
