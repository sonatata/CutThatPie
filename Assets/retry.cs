using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour {

    private GameObject lvls;

    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        lvls = GameObject.Find("LvlSys");
        //lvls.GetComponent<LevelCntrl>().level += 1;
        SceneManager.LoadScene(lvls.GetComponent<LevelCntrl>().level);
        //SceneManager.LoadScene(1);
    }

    public void newlevel()
    {
        Application.LoadLevel(2);
    }
}
