using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialcontroller : MonoBehaviour {

	public GameObject client1;
	public GameObject client2;
	public GameObject fraction;
	public GameObject pie;
	private bool served;
	public string want;
	public Vector2 aPosition1;
	public int speed;
	public bool playing;
	public Texture2D texture;
	public Text txt;
	private bool m1;
	private bool m2;
	private bool m3;
	private bool m4;
	private bool m5;
	private bool p1;
	private bool p2;
	private bool p3;
	private bool p4;
	private float displayTime;

    //public GameObject arrow3;


    // Use this for initialization
	void Start (){
		displayTime = 0.0f;
		texture = new Texture2D(100, 1);
		playing = false;
		m1 = true;
		m2 = false;
		m3 = false;

        //EndPanel.SetActive(false);
        //arrow3.SetActive(false);

        //winText.text = "";
        //loseText.text = "";

    }
	
	// Update is called once per frame
	void Update () {
		/*if (m1) {
			if (displayTime >= 3.5f) {
				playing = false;
				m1 = false;
				m2 = true;
			}
		} else if (m2) {
			if (displayTime >= 3.5f) {
				playing = false;
				m2 = false;
				m3 = true;
			}*/
		


		if (p1 || p2 || p3 || p4) {
			if (client1) {
				client1.transform.position = Vector2.MoveTowards (new Vector2 (client1.transform.position.x,
					client1.transform.position.y), aPosition1, Time.deltaTime * speed);
			}
			client2.transform.position = Vector2.MoveTowards (new Vector2 (client2.transform.position.x,
				client2.transform.position.y), aPosition1, Time.deltaTime * speed);
			if (p1) {
				if (displayTime > 2.0f) {
					p1 = false;
					m2 = true;
					displayTime = 0.0f;
				} 
			}else if (p3) {
				if (displayTime > 2.0f) {
					displayTime = 0.0f;
					p3 = false;
					m4 = true;
				}
			}

		}

		displayTime += Time.deltaTime;
		if (m1 && displayTime >= 1.0f) {
			m1 = false;
			p1 = true;
			displayTime = 0.0f;
		} 
		if (m2 && displayTime >= 1.0f) {
			m2 = false;
			p2 = true;
			displayTime = 0.0f;
		} 
		if (m3) {
			if (displayTime >= 2.0f) {
				displayTime = 0.0f;
				m3 = false;
				p3 = true;
			}
		}
		if (m4) {
			if (displayTime >= 3.0f) {
				displayTime = 0.0f;
				m4 = false;
				m5 = true;
			}

		}
		if (m5) {
			if (displayTime >= 3.0f) {
				m5 = false;
				p4 = true;

			}

		}

		/*while (playing) {
			if (m1) {
				if (displayTime >= 3.5f) {
					playing = false;
					m1 = false;
					m2 = true;
				}
			} else if (m2) {
				if (displayTime >= 3.5f) {
					playing = false;
					m2 = false;
					m3 = true;
				}
			} else if (m3) {
				if (displayTime >= 3.5f) {
					//m1 = false;
					//m2 = true;
				}
			}
		}*/

		//Debug.Log (displayTime);


	}

    /*private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag (want) && !served) 
			{
				Destroy (other.gameObject);
				Destroy (fraction.gameObject);
				Destroy (pie.gameObject);
				//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
				//Instantiate (thanks, new Vector2 (fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
				//rightwrong.text = "Thanks!";
				displaymessage = true;
				displayTime = 3.0f;
				served = true;
				count = count + 1;
				SetCountText ();
				Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
            
            //arrow3.SetActive(true);

			}
		else if (!served && !wronged)
		{
			Destroy(other.gameObject);
			Destroy(fraction.gameObject);
			Destroy(pie.gameObject);
			//rightwrong.text = "Wrong";
			wronged = true;
			displaymessage = true;
			displayTime = 3.0f;
			//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
			//Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
            //arrow3.SetActive(true);
        }
       


    }

    void SetCountText()
    {
        countText.text = "PIES COLLECTED " + count.ToString();
        if(count == 2 && level == 1)
        {
            //winText.text = "You Win!";
            //SceneManager.LoadScene(2);
            Time.timeScale = 0;
            EndPanel.SetActive(true);
        }
        if (count == 5 && level == 2)
        {
            //winText.text = "You Win!";
            SceneManager.LoadScene(4);
        }
    }*/
	void OnGUI() {
		if (!p1 && !p2 && !p3 && !p4) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texture, ScaleMode.StretchToFill, true, 10.0F);
			if (m1) {
				txt.text = "This is your pie shop!";
				//displayTime = 0.0f;
			} else if (m2) {
				txt.text = "Drag the blue pie to you first customer!";
				//displayTime = 0.0f;
			} else if (m3) {
				txt.text = "GREAT !";
				Destroy (client1);
				//displayTime = 0.0f;
			} else if (m4) {
				txt.text = "The Second Customer needs a fraction!!";
				//displayTime = 0.0f;
			} else if (m5) {
				txt.text = "Drag pie to the Board!";
			}
		}else {
			txt.text = "";
		}

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		/*if (p2 && other.gameObject.CompareTag (want) && !served) 
		{
			Destroy (other.gameObject);
			Destroy (fraction.gameObject);
			Destroy (pie.gameObject);
			//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
			//Instantiate (thanks, new Vector2 (fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
			//rightwrong.text = "Thanks!";
			//displaymessage = true;
			//displayTime = 3.0f;
			served = true;
			p2 = false;
			displayTime = 0.0f;
			m3 = true;
			//count = count + 1;
			//SetCountText ();
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);

			//arrow3.SetActive(true);

		}
		else if (!served)
		{
			Destroy(other.gameObject);
			Destroy(fraction.gameObject);
			Destroy(pie.gameObject);
			//rightwrong.text = "Wrong";
			//wronged = true;
			//displaymessage = true;
			//displayTime = 3.0f;
			//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
			//Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
			//arrow3.SetActive(true);
		}*/



	}
	public void triggered(GameObject triggered, GameObject other){
		if (p2  && !served) 
		{
			Destroy (other.gameObject);
			Destroy (fraction.gameObject);
			Destroy (pie.gameObject);
			//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
			//Instantiate (thanks, new Vector2 (fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
			//rightwrong.text = "Thanks!";
			//displaymessage = true;
			//displayTime = 3.0f;
			served = true;
			p2 = false;
			displayTime = 0.0f;
			m3 = true;
			Debug.Log ("here");
			//count = count + 1;
			//SetCountText ();
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);


			//arrow3.SetActive(true);

		}
		else if (!served)
		{
			Destroy(other.gameObject);
			Destroy(fraction.gameObject);
			Destroy(pie.gameObject);
			//rightwrong.text = "Wrong";
			//wronged = true;
			//displaymessage = true;
			//displayTime = 3.0f;
			//Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
			//Instantiate(wrong, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
			//arrow3.SetActive(true);
		}

	}
}
/*if (want == "half")
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
		if (other.gameObject.CompareTag ("whole")) {
			Instantiate (prefabManager.Instance.PiePrefab, new Vector2 (6, -3), Quaternion.identity);
		}
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
		if (other.gameObject.CompareTag ("whole")) {
			Instantiate (prefabManager.Instance.PiePrefab, new Vector2 (6, -3), Quaternion.identity);
		}
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
		if (other.gameObject.CompareTag ("whole")) {
			Instantiate (prefabManager.Instance.PiePrefab, new Vector2 (6, -3), Quaternion.identity);
		}
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
		if (other.gameObject.CompareTag ("whole")) {
			Instantiate (prefabManager.Instance.PiePrefab, new Vector2 (6, -3), Quaternion.identity);
		}
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
		if (other.gameObject.CompareTag ("whole")) {
			Instantiate (prefabManager.Instance.PiePrefab, new Vector2 (6, -3), Quaternion.identity);
		}
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

	}*/
