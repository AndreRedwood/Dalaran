using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	private PolygonCollider2D collider;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		collider = GetComponent<PolygonCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnMouseEnter()
	{
		spriteRenderer.color = Color.red;
	}

	private void OnMouseExit()
	{
		spriteRenderer.color = Color.white;
	}

	private void OnMouseDown()
	{
		Debug.Log("Trans Coordinate:" + transform.position.x + " ; " + transform.position.y);
		float xCoordinate = (transform.position.y - transform.position.x) * 0.5f;
		float yCoordinate = (transform.position.y + transform.position.x) * 0.5f;
		Debug.Log("Coordinate:" + xCoordinate + " ; " + yCoordinate);
	}
}
