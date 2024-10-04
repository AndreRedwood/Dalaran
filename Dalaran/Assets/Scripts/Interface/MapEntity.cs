using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntity : MonoBehaviour
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

	public void SetupEntity(int x, int y, int height, MapDisplayManager manager)
	{
		this.x = x;
		this.y = y;
		Height = height;
		SetPosition(x, y, height);
		mapDisplayManager = manager;
	}

	private void SetPosition(int x, int y, int height)
	{
		float xPosition = x * 0.5f + y * -0.5f;
		float yPosition = (x * 0.25f + y * 0.25f) + (height * 0.25f) + 0.25f;
		float zPosition = (height + 1) * -1;
		transform.position = new Vector3(xPosition, yPosition, zPosition );
	}

	protected virtual void OnMouseEnter()
	{
		spriteRenderer.color = Color.blue;
		mapDisplayManager.HoverTile(x, y);
	}

	protected void OnMouseExit()
	{
		spriteRenderer.color = Color.white;
		mapDisplayManager.UnHoverTile();
	}
}
