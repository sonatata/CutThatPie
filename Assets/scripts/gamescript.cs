using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamescript : MonoBehaviour {

	// Use this for initialization
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
		
		}

	}
}
