using UnityEngine;
using System.Collections;

public class BlockDragEvents : MonoBehaviour {

    public Color dragColor;
    public SpriteRenderer dragIndicatorRenderer;
    public TextMesh dragTimeIndicatorTextMesh;

    protected bool isDragging = false;
    protected Color originalIndicatorColor;

    //This event is called when you first pick up this GameObject
	void OnStartDrag()
    {
        isDragging = true;

        dragTimeIndicatorTextMesh.text = "0";

        originalIndicatorColor = gameObject.GetComponent<SpriteRenderer>().color;
        dragIndicatorRenderer.color = dragColor;
    }

    //This event is called when you drop this GameObject
    void OnStopDrag()
    {
        isDragging = false;

        dragTimeIndicatorTextMesh.text = "0";

        dragIndicatorRenderer.color = originalIndicatorColor;
    }

    //You can use a bool to indicate whether the GameObject is currently being dragged.
    void Update()
    {
        if(isDragging)
        {
            //For example, here we are updating a clock in the scene to show drag time
            float currentTime = float.Parse(dragTimeIndicatorTextMesh.text);
            dragTimeIndicatorTextMesh.text = (currentTime + Time.deltaTime).ToString();
        }
    }
}
