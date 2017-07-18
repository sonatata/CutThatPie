using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    private string str;
    public Rect textplace;
    void Start()
    {
        
        StartCoroutine(AnimateText("Pretty cool text"));
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

    void OnGUI()
    {
        GUI.Label(textplace, str);
        //GUI.Box(new Rect(505, 4, 200, 100), str);
    }
}
