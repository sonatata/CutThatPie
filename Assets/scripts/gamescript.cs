using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamescript : MonoBehaviour {

	// Use this for initialization
	public GameObject half;
	public GameObject qrtr;
	public GameObject eth;
    public GameObject threeeth;
    public GameObject sth;
    public GameObject thrqrtr;
    public GameObject fiveeth;
    public GameObject go;
    public GameObject exit;

    public GameObject glass;

    //List<GameObject> DeadList = new List<GameObject>();
	Vector3 screenPoint;
	Vector3 offset;
    private List<GameObject> objlist = new List<GameObject>();
    public GameObject[] DeadList;
    public GameObject knife;
	private GameObject lasthit;
	void Start () {
        SpriteRenderer rend = glass.gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        //Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);

    }


 //   void OnMouseDown()
	//{
	//	screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

	//	offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    public void selfDistruct()
    {
        Destroy(go);
        Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
    }
	//}

	//void OnMouseDrag()
	//{
	//	Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);    
	//	Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
	//	knife.transform.position = curPosition;
	//}
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

        //else if (objlist.Contains(collision.gameObject.transform.parent.gameObject)){

        //	SpriteRenderer rend = collision.gameObject.GetComponent<SpriteRenderer>();
        //	rend.enabled = true;
        //	objlist.Add(collision.gameObject);
        //	if (collision.gameObject.CompareTag("invisible"))
        //	{
        //		collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //	}
        if (collision.gameObject.CompareTag("checkpoint"))
        {

            
            DeadList = GameObject.FindGameObjectsWithTag("half");
            Debug.Log(DeadList.ToString());
            if (DeadList.Length > 0)
            {
                for (int i = 0; i < DeadList.Length - 1; i++)
                {
                    Destroy(DeadList[i]);
                }
            }
            DeadList = GameObject.FindGameObjectsWithTag("qrtr");
            if (DeadList.Length > 0)
                {
                    for (int i = 0; i < DeadList.Length - 1; i++)
                    {
                        Destroy(DeadList[i]);
                    }
             }
            DeadList = GameObject.FindGameObjectsWithTag("8th");
            if (DeadList.Length > 0)
                    {
                        for (int i = 0; i < DeadList.Length - 1; i++)
                        {
                            Destroy(DeadList[i]);
                        }
            }
            DeadList = GameObject.FindGameObjectsWithTag("3/8");
            if (DeadList.Length > 0)
                        {
                            for (int i = 0; i < DeadList.Length - 1; i++)
                            {
                                Destroy(DeadList[i]);
                            }
            }
            DeadList = GameObject.FindGameObjectsWithTag("3/4");
            if (DeadList.Length > 0)
                            {
                                for (int i = 0; i < DeadList.Length - 1; i++)
                                {
                                    Destroy(DeadList[i]);
                                }
            }
            DeadList = GameObject.FindGameObjectsWithTag("7/8");
            if (DeadList.Length > 0)
            {
                                    for (int i = 0; i < DeadList.Length - 1; i++)
                                    {
                                        Destroy(DeadList[i]);
                                    }
            }
            DeadList = GameObject.FindGameObjectsWithTag("5/8");
            if (DeadList.Length > 0)
                                    {
                                        for (int i = 0; i < DeadList.Length - 1; i++)
                                        {
                                            Destroy(DeadList[i]);
                                        }

            }
                                
            SpriteRenderer rend = glass.gameObject.GetComponent<SpriteRenderer>();
            rend.enabled = false;

            if (collision.gameObject.name == "1/2")
					{
						Destroy(go);
						//Instantiate(half, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                      
						Instantiate(half, new Vector2(-7f,-2.8f ), Quaternion.identity);
                        Instantiate(half, new Vector2(-5f, -2.8f), Quaternion.identity);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                //Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                //flag = true;
            }
					if (collision.gameObject.name == "1/4")
					{
						Destroy(go);
                        
						Instantiate(qrtr, new Vector2(-7.1f, -2.5f), Quaternion.identity);
                        Instantiate(thrqrtr, new Vector2(-5.1f, -2.5f), Quaternion.identity);
                //flag = true;
            }
					if (collision.gameObject.name == "1/8")
					{
						Destroy(go);
						Instantiate(eth, new Vector2(-5.1f, -2.5f), Quaternion.identity);
                Instantiate(sth, new Vector2(-7f, -2.5f), Quaternion.identity);
                //flag = true;
            }
                if (collision.gameObject.name == "3/8")
                {
                    Destroy(go);
                    Instantiate(threeeth, new Vector2(-7f, -2.5f), Quaternion.identity);
                Instantiate(fiveeth, new Vector2(-5.1f, -2.5f), Quaternion.identity);
                //flag = true;
            }
                if (collision.gameObject.name == "5/8")
                {
                    Destroy(go);
                    Instantiate(fiveeth, new Vector2(-7.1f, -2.5f), Quaternion.identity);
                Instantiate(threeeth, new Vector2(-5.1f, -2.5f), Quaternion.identity);
                //flag = true;
            }
                // do something with master //hlf
                //Master.cut_frac = other.gameObject.name;
                //Master.is_cut = true;

                //chkpts += 1;
            }
            else if (collision.gameObject.CompareTag("client"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
		
	//	}

	}
}
