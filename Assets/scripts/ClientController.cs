using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientController : MonoBehaviour {

    public Vector2 aPosition1 = new Vector2(-5, 2);
    public GameObject plate;
    public GameObject fraction;
    public GameObject pie;
    public GameObject thanks;
    public GameObject wrong;
    public string want;
    public int speed;

    public Text countText;
    private static int count;
    private bool ded;

    public Text winText;
    public Text loseText;
    // Use this for initialization
    void Start () {
        count = 0;
        
        ded = false;
        SetCountText();
        //winText.text = "";
        //loseText.text = "";

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,
            transform.position.y), aPosition1, Time.deltaTime*speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (want == "half")
        {
            if (other.gameObject.CompareTag("half"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                count = count + 1;
                SetCountText();

            }
            else if (other.gameObject.CompareTag("qrtr") || other.gameObject.CompareTag("8th") 
                || other.gameObject.CompareTag("3/8") || other.gameObject.CompareTag("5/8")
                || other.gameObject.CompareTag("whole"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        } else if(want == "qrtr")
        {
            if (other.gameObject.CompareTag("qrtr"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                count = count + 1;
                SetCountText();

            }
            else if (other.gameObject.CompareTag("half") || other.gameObject.CompareTag("8th") 
                || other.gameObject.CompareTag("3/8") || other.gameObject.CompareTag("5/8")
                || other.gameObject.CompareTag("whole"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        }
        else if (want == "8th")
        {
            if (other.gameObject.CompareTag("8th"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                count = count + 1;
                SetCountText();
            }
            else if (other.gameObject.CompareTag("half") || other.gameObject.CompareTag("qrtr") 
                || other.gameObject.CompareTag("3/8") || other.gameObject.CompareTag("5/8") 
                || other.gameObject.CompareTag("whole"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        }
        else if (want == "3/8")
        {
            if (other.gameObject.CompareTag("3/8"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                count = count + 1;
                SetCountText();
            }
            else if (other.gameObject.CompareTag("half") || other.gameObject.CompareTag("qrtr") 
                || other.gameObject.CompareTag("5/8") || other.gameObject.CompareTag("8th")
                || other.gameObject.CompareTag("whole"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        }
        else if (want == "5/8")
        {
            if (other.gameObject.CompareTag("5/8"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                count = count + 1;
                SetCountText();
            }
            else if (other.gameObject.CompareTag("half") || other.gameObject.CompareTag("qrtr") 
                || other.gameObject.CompareTag("3/8") || other.gameObject.CompareTag("8th")
                || other.gameObject.CompareTag("whole"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        }
        else if (want == "whole")
        {
            if (other.gameObject.CompareTag("whole"))
            //if (Master.cut_frac == "1/2")
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
                count = count + 1;
                SetCountText();
            }
            else if (other.gameObject.CompareTag("half") || other.gameObject.CompareTag("qrtr") 
                || other.gameObject.CompareTag("3/8") || other.gameObject.CompareTag("5/8") 
                || other.gameObject.CompareTag("8th"))
            {
                Destroy(other.gameObject);
                Destroy(fraction.gameObject);
                Destroy(pie.gameObject);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
            }
            else
            {

            }
        }


    }

    void SetCountText()
    {
        countText.text = "PIES COLLECTED " + count.ToString();
        if(count == 2)
        {
            //winText.text = "You Win!";
            SceneManager.LoadScene(4);
        }
    }
}
