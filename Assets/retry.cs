using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour {

    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        
        SceneManager.LoadScene(1);
    }

    public void newlevel()
    {
        Application.LoadLevel(2);
    }
}
