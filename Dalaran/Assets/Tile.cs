using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	private PolygonCollider2D collider;
	private SpriteRenderer spriteRenderer;

	[SerializeField] private Sprite h0, h1, h2;
	private int height = 0;

	private void Awake()
	{
		collider = GetComponent<PolygonCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetHeight(int height)
	{
		this.height = height;
		switch (height)
		{
			case 0: spriteRenderer.sprite = h0; collider.offset = new Vector2(0, 0); break;
			case 1: spriteRenderer.sprite = h1; collider.offset = new Vector2(0, 0.25f); break;
			case 2: spriteRenderer.sprite = h2; collider.offset = new Vector2(0, 0.5f); break;
		}
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
