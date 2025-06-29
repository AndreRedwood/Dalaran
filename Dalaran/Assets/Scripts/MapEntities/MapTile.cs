using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
	[SerializeField]
	private BattleUIManager manager;
	[SerializeField]
	private int x, y;
	[SerializeField]
	private int tileHeight;

    public void SetupTile(BattleUIManager manager, int x, int y, int height)
    {
		this.manager = manager;
		this.x = x;
		this.y = y;
		tileHeight = height;
		TilePositioner.PositionTile(transform, x, y);
		TilePositioner.PositionCollider(GetComponent<BoxCollider>(), tileHeight);
    }

	private void OnMouseEnter()
	{
		manager.TileHover(new Vector2Int(x, y));
	}
}
