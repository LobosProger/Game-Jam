using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	Vector2 initialPos;
	Vector2 destinationPos;

	KeyHole holeWithin = null;
	bool isInPosition = false;
	bool isDragged;

	//Main key from which would be identified if block can be put into 
	public int keyID;

	void Start()
	{
		initialPos = this.transform.position;
		destinationPos = initialPos;
	}

	private void Update()
	{
		if (!isDragged)
        {
			this.transform.position = Vector2.Lerp(this.transform.position, destinationPos, Time.deltaTime * 6f);

		}
	}

	public void OnMouseDrag()
	{
		if (!isInPosition)
			this.transform.position = Input.mousePosition;
		isDragged = true;
	}

	public void OnMouseUp()
	{
		if (holeWithin == null)
			destinationPos = initialPos;
		else
		{
			bool isCorrect = holeWithin.OnHoleFillAttempt(this);
			if (!isCorrect)
				destinationPos = initialPos;
			else
			{
				isInPosition = true;
				destinationPos = holeWithin.transform.position;
			}
		}
		isDragged = false;
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
