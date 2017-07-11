using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour {

    private Vector2 _centre;
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
                                //public GameObject tool_location;
                                // Use this for initialization

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;
    
    private float _angle;
    // Use this for initialization
    void Start () {
        _centre = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
         _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

        //transform.position.x = 0;
        //transform.position.x = Mathf.Sin(Time.time * speed);
        //transform.position = transform.position + new Vector3(0, Mathf.Sin(Time.time * speed), 0);

    }

    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }
}
