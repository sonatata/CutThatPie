using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    public Camera cam;
    public float distanceFromCamera;
    public Transform sphere;
    Rigidbody r;
	// Use this for initialization
	void Start () {
        distanceFromCamera = Vector3.Distance(sphere.position, cam.transform.position);
        r = sphere.GetComponent<Rigidbody>();
		
	}
    Vector3 lastPos;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = cam.ScreenToWorldPoint(pos);
            r.velocity = ((pos - sphere.position) * 10);

            //sphere.position = pos;
        }

		
	}
}
