using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traceContrlr : MonoBehaviour {

    private bool flag = false;
	// Use this for initialization
	void Start () {
        
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!flag)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knife"))
        {
            Debug.Log("hey");
            flag = true;
        }
        

    }
    


}
