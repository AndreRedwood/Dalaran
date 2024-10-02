using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
	private new PolygonCollider2D collider;
	private SpriteRenderer spriteRenderer;
	private int x, y;
	public int Height { private set; get; }

	private MapDisplayManager mapDisplayManager;

	private void Awake()
	{
		collider = GetComponent<PolygonCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetupTile(int[] coordinates, int height, Sprite sprite, MapDisplayManager manager)
	{
		x = coordinates[0];
		y = coordinates[1];
		Height = height;
		spriteRenderer.sprite = sprite;
		collider.offset = new Vector2(0, height * 0.25f);
		mapDisplayManager = manager;
	}

	private void OnMouseEnter()
	{
		spriteRenderer.color = Color.red;
		mapDisplayManager.DisplayTileInfo(x, y);
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
