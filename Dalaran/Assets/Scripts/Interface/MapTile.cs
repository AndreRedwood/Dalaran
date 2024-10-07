using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MapEntity
{
	public void SetupTile(int x, int y, int height, Sprite sprite, BattleDisplayManager manager)
	{
		SetupEntity(x, y, height, manager);
		SetPosition(x, y, height);
		spriteRenderer.sprite = sprite;
		collider.offset = new Vector2(0, (height - 1) * 0.25f);
	}

	protected override void SetPosition(int x, int y, int height)
	{
		float xPosition = x * 0.5f + y * -0.5f;
		float yPosition = x * 0.25f + y * 0.25f;
		transform.position = new Vector3(xPosition, yPosition, 0);
	}

	protected override void OnMouseEnter()
	{
		spriteRenderer.color = Color.red;
		battleDisplayManager.HoverTile(x, y);
	}

	protected override void OnMouseExit()
	{
		spriteRenderer.color = Color.white;
		battleDisplayManager.UnHoverTile();
	}
}
