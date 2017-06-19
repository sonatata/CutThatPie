using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slice_display : MonoBehaviour {

    void OnMouseDown()
    {
        transform.localScale *= 1.1F;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(1);
    }
}
