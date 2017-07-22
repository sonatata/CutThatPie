using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    private string str;
    public GameObject textbox;
    public Rect textplace;
    void Start()
    {
        textbox.SetActive(false);
        StartCoroutine(AnimateText("Hello there! and welcome to your very own pie shop!"));
    }


    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.02F);
        }
    }

    private void Update()
    {
        textbox.SetActive(true);
    }
    //void OnGUI()
    //{
    //    //GUI.Label(textplace, str);
    //    GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f); //0.5 is half opacity 
        
    //    GUI.Box(new Rect(505, 4, 200, 100), str);
    //}
}
