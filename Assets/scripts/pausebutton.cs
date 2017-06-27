using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausebutton : MonoBehaviour {
    private bool press = false;
    public Transform canvas;

    // Use this for initialization
    void Start () {
        transform.localScale *= 1.1F;
        press = false;
    }

    private void OnMouseDown()
    {
        press = true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (press)
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
