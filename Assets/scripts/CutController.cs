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
    public GameObject placeholder;
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
            Instantiate(roundPiePrefab, new Vector2(0, 0), Quaternion.identity);

            //destroys pie colliding with knife 
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("wall"))
        {

            Instantiate(prefabManager.Instance.PiePrefab, new Vector2(2.58f, -2.7f), Quaternion.identity);

            
        }


    }
}
