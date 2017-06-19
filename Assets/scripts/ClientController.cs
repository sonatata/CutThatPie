using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClientController : MonoBehaviour {

    public Vector2 aPosition1 = new Vector2(-5, 2);
    public GameObject plate;
    public GameObject fraction;
    public GameObject pie;
    public GameObject thanks;
    public GameObject wrong;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,
            transform.position.y), aPosition1, 3 * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("half"))
		if (Master.cut_frac == "1/2")
        {
            Destroy(other.gameObject);
            Destroy(fraction.gameObject);
            Destroy(pie.gameObject);
            //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
            Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);

        } else
        {
            Destroy(other.gameObject);
            Destroy(fraction.gameObject);
            Destroy(pie.gameObject);
            //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
            Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
        }

    }
}
