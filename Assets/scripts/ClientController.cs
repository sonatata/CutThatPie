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
    public float speed;
    public int level;
	private bool served;
	private bool wronged;
	private bool displaymessage;
	private float displayTime;

    // audio
    public AudioSource yes;
    public AudioSource no;

    public Text countText;
	public Text rightwrong;
    private static int count;
    private bool ded;
    

    public GameObject EndPanel;

    public Text winText;
    public Text loseText;
    // Use this for initialization
    void Start () {
        count = 0;
        EndPanel.SetActive(false);

        ded = false;
		served = false;
		wronged = false;
        SetCountText();
		displayTime = 0.0f;
        //winText.text = "";
        //loseText.text = "";

    }

    private void Awake()
    {
        //GetComponent<AudioSource>().clip = yes;
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,
            transform.position.y), aPosition1, Time.deltaTime*speed);

		displayTime -= Time.deltaTime;
		//Debug.Log (displayTime);
		//Debug.Log (displaymessage);
		if (displayTime <= 0.0f) {
			displaymessage = false;
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
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
            yes.Play();
            
            
            
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
            no.Play();
            //arrow3.SetActive(true);
        }
       


    }

    void SetCountText()
    {
        countText.text = "CLIENTS SERVED:  " + count.ToString();
        if(count == 2 && level == 1)
        {
            //winText.text = "You Win!";
            //SceneManager.LoadScene(2);
            Time.timeScale = 0;
            EndPanel.SetActive(true);
        }
        if (count == 4 && level == 2)
        {
            //winText.text = "You Win!";
            SceneManager.LoadScene(5);
        }
    }
	void OnGUI() {
		if (displaymessage) {
			if (served) {
				rightwrong.text = "thanks!";
			} else if (wronged) {
				rightwrong.text = "wrong!";
			}
		} else {
			rightwrong.text = "";
		}

	}
}
