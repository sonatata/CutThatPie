using UnityEngine;
using System.Collections;

public class newgame : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(1);
    }
}
