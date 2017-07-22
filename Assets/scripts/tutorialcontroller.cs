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
	public float speed;
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
        

    }
	
	// Update is called once per frame
	void Update () {


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
		if (m1 && displayTime >= 3.0f) {
			m1 = false;
			p1 = true;
			displayTime = 0.0f;
		} 
		if (m2 && displayTime >= 4.0f) {
			m2 = false;
			m3 = true;
			displayTime = 0.0f;
		} 
		if (m3) {
            // great!
			if (displayTime >= 4.0f) {
				
				m3 = false;
				p3 = true;
                m4 = true;
                displayTime = 0.0f;
			}
		}
		if (m4) {
			if (displayTime >= 4.0f) {
				
				m4 = false;
				m5 = true;
                displayTime = 0.0f;
			}

		}
        if (m5)
        {
            if (displayTime >= 5.0f)
            {
                m5 = false;
                p4 = true;

            }
        }



	}
    
	void OnGUI() {
		if (!p1 && !p2 && !p3 && !p4) {
            //GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texture, ScaleMode.StretchToFill, true, 10.0F);
            GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.1f); //0.5 is half opacity 
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height),txt.text);
            GUI.color = Color.white;
            if (m1) {
				txt.text = "Welcome to your pie shop!";
				//displayTime = 0.0f;
			} else if (m2) {
				txt.text = "Drag the golden pie to your first customer!";
				//displayTime = 0.0f;
			} else if (m3) {
				txt.text = "Pay attention to the top left panel to track your progress!";
				//Destroy (client1);
				//displayTime = 0.0f;
			} else if (m4) {
				txt.text = "The Second Customer needs a fraction!!";
				//displayTime = 0.0f;
			} else if (m5) {
				txt.text = "Drag pie to the Cutting Board & CUT THAT PIE! by using the pink dot";
			}
    }else {
			txt.text = "";
		}

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		



	}
	public void triggered(GameObject triggered, GameObject other){
		if (p2  && !served) 
		{
			Destroy (other.gameObject);
			Destroy (fraction.gameObject);
			Destroy (pie.gameObject);
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
			Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);
		}

	}
}

