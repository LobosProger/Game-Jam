using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector2 initialPos;
    Rect rectTransform;

    //Main key from which would be identified if block can be put into 
    public int key;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>().rect;
        initialPos = this.transform.position;
    }

    public void OnMouseDrag()
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnMouseUp()
    {
        bool isInHole = GeneralFunctions.CheckAllHoles();
        if(!isInHole)
            this.transform.position = initialPos;
    }
}
