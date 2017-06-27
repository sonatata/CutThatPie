using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
    public bool pressed;
    private pausebutton script;


	// Use this for initialization
	void Start () {
    }
    

    void Update()
    {

    }

    public void Pause()
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

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        Application.LoadLevel(0);
    }
}
