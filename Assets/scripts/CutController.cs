using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutController : MonoBehaviour {

    public GameObject half;
    public GameObject qrtr;
    public GameObject eth;
    bool flag = false;
    //public GameObject tool_location;
	// Use this for initialization
	
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!flag)
        {
            if (Master.cut_frac == "1/2")
            {

                Instantiate(half, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                //Instantiate(plate, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity);
                //Instantiate(thanks, new Vector2(fraction.transform.position.x, fraction.transform.position.y), Quaternion.identity);
                flag = true;
            }
            if(Master.cut_frac == "1/4")
            {
                Instantiate(qrtr, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                flag = true;
            }
            if (Master.cut_frac == "1/8")
            {
                Instantiate(eth, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.transform);
                flag = true;
            }

        }

    }


    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("pie"))
        {
			//Application.LoadLevel("_Scenes/minigame");
			SceneManager.LoadScene ("cut", LoadSceneMode.Additive);

            Destroy(other.gameObject);
            //Instantiate(result, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity, plate.transform);
        }

        
    }
}
