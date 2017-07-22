using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutController : MonoBehaviour {

    //public GameObject half;
    //public GameObject qrtr;
    //public GameObject eth;
    public GameObject roundPiePrefab;
    public GameObject fullpie;
    public GameObject instance;
    public GameObject glass;
    bool flag = false;
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
                                //public GameObject tool_location;
                                // Use this for initialization

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;
    

    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("cuttingBoard"))
        {
            //glass.SetActive(true);
            //SpriteRenderer rend = glass.gameObject.GetComponent<SpriteRenderer>();
            //rend.enabled = true;
            //creates a pie module to cut on 
            Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);

            //Application.LoadLevel("_Scenes/minigame");
            //SceneManager.LoadScene ("cut", LoadSceneMode.Additive);

            //destroys pie colliding with knife 
            Destroy(this.gameObject);
            //arrow4.SetActive(true);
            //Instantiate(prefabManager.Instance.PiePrefab, new Vector2(6, -3), Quaternion.identity);



            //Instantiate(result, new Vector2(plate.transform.position.x, plate.transform.position.y), Quaternion.identity, plate.transform);
        }


    }
}
