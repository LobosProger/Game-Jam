using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public Vector2 initialPos;

	//Main key from which would be identified if block can be put into 
	public int key;

	void Start()
	{
		initialPos = this.transform.position;
	}

	public void OnMouseDrag()
	{
		this.transform.position = Input.mousePosition;
	}

	public void OnMouseUp()
	{
		this.transform.position = initialPos;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision");
	}
}
