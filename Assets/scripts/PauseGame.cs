﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
    public bool pressed;
    private pausebutton script;
    private GameObject lvls;


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

    public void NextLevel()
    {
        lvls = GameObject.Find("LvlSys");
        lvls.GetComponent<LevelCntrl>().level += 1;
        SceneManager.LoadScene(lvls.GetComponent<LevelCntrl>().level);
        Time.timeScale = 1;
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
