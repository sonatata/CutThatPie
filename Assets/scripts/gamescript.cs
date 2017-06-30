using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamescript : MonoBehaviour {

	// Use this for initialization
	public GameObject half;
	public GameObject qrtr;
	public GameObject eth;
    public GameObject threeeth;
    public GameObject fiveeth;
    public GameObject go;
	Vector3 screenPoint;
	Vector3 offset;
	private List<GameObject> objlist = new List<GameObject>();
    public GameObject knife;
	private GameObject lasthit;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);    
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		knife.transform.position = curPosition;
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Respawn")){
			objlist.Add(collision.gameObject);
			Debug.Log ("first collide");
			SpriteRenderer rend = collision.gameObject.GetComponent<SpriteRenderer>();
			rend.enabled = true;
			objlist.Add(collision.gameObject);
		}
		//Debug.Log ("here");
		//Debug.Log(collision.gameObject.transform.parent.gameObject.name);

		else if (objlist.Contains(collision.gameObject.transform.parent.gameObject)){
			
			SpriteRenderer rend = collision.gameObject.GetComponent<SpriteRenderer>();
			rend.enabled = true;
			objlist.Add(collision.gameObject);
			if (collision.gameObject.CompareTag("invisible"))
			{
				collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
			if (collision.gameObject.CompareTag("checkpoint"))
			{
				
					if (collision.gameObject.name == "1/2")
					{
						Destroy(go);
						//Instantiate(half, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
						Instantiate(half, new Vector2(-6.1f,-2.8f ), Quaternion.identity);
						//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
						//Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
						//flag = true;
					}
					if (collision.gameObject.name == "1/4")
					{
						Destroy(go);
						Instantiate(qrtr, new Vector2(-6.1f, -2.8f), Quaternion.identity);
						//flag = true;
					}
					if (collision.gameObject.name == "1/8")
					{
						Destroy(go);
						Instantiate(eth, new Vector2(-6.1f, -2.8f), Quaternion.identity);
						//flag = true;
					}
                if (collision.gameObject.name == "3/8")
                {
                    Destroy(go);
                    Instantiate(threeeth, new Vector2(-6.1f, -2.8f), Quaternion.identity);
                    //flag = true;
                }
                if (collision.gameObject.name == "5/8")
                {
                    Destroy(go);
                    Instantiate(fiveeth, new Vector2(-6.1f, -2.8f), Quaternion.identity);
                    //flag = true;
                }
                // do something with master //hlf
                //Master.cut_frac = other.gameObject.name;
                //Master.is_cut = true;

                //chkpts += 1;
            }
		
		}

	}
}
