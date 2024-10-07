using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntity : MonoBehaviour
{
	protected new PolygonCollider2D collider;
	protected SpriteRenderer spriteRenderer;
	protected int x, y;
	public int Height { protected set; get; }

	protected BattleDisplayManager battleDisplayManager;

	private void Awake()
	{
		collider = GetComponent<PolygonCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetupEntity(int x, int y, int height, BattleDisplayManager manager)
	{
		this.x = x;
		this.y = y;
		Height = height;
		battleDisplayManager = manager;
	}

	protected virtual void SetPosition(int x, int y, int height)
	{
		float xPosition = x * 0.5f + y * -0.5f;
		float yPosition = (x * 0.25f + y * 0.25f) + (height * 0.25f) + 0.25f;
		float zPosition = (height + 1) * -1;
		transform.position = new Vector3(xPosition, yPosition, zPosition );
	}

	protected virtual void OnMouseEnter()
	{
		spriteRenderer.color = Color.blue;
		battleDisplayManager.HoverTile(x, y);
	}

	protected virtual void OnMouseExit()
	{
		spriteRenderer.color = Color.white;
		battleDisplayManager.UnHoverTile();
	}
}
