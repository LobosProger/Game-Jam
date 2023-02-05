using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
	private static Camera mainCamera;

	Vector2 initialPos;
	Vector2 destinationPos;

	KeyHole holeWithin = null;
	bool isInPosition = false;
	bool isDragged;

	//Main key from which would be identified if block can be put into 
	public int keyID;

	void Start()
	{
		if (mainCamera == null)
			mainCamera = Camera.main;

		initialPos = this.transform.position;
		destinationPos = initialPos;
	}

	private void Update()
	{
		if (!isDragged)
        {
			this.transform.position = Vector2.Lerp(this.transform.position, destinationPos, Time.deltaTime * 6f);
			//MovementRotation();
		}
	}

	public void OnMouseDrag()
	{
		if (!isInPosition)
		{
			var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			screenPoint.z = 10.0f; //distance of the plane from the camera
			transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
		}
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
				GetComponent<ParticleSystem>().Play();
				GetComponent<Image>().raycastTarget = false;
			}
		}
		isDragged = false;
	}

	void MovementRotation()
    {

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
