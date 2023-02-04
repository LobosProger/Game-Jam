using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 initialPos;
    KeyHole holeWithin = null;
    bool isInPosition = false;

    //Main key from which would be identified if block can be put into 
    public int keyID;

    void Start()
    {
        initialPos = this.transform.position;
    }

    public void OnMouseDrag()
    {
        if(!isInPosition)
            this.transform.position = Input.mousePosition;
    }

    public void OnMouseUp()
    {
        if (holeWithin == null)
            this.transform.position = initialPos;
        else
        {
            bool isCorrect = holeWithin.OnHoleFill(this);
            if (!isCorrect)
                this.transform.position = initialPos;
            else
            {
                isInPosition = true;
                this.transform.position = holeWithin.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out KeyHole hole))
        {
            holeWithin = hole;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<KeyHole>())
        {
            holeWithin = null;
        }
    }
}
