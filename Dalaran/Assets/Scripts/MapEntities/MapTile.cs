using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
	[SerializeField]
	private BattleManager manager = BattleManager.GetInstance();
	[SerializeField] //is it really nedeed?
	private BattleUIManager managerUI;

	[SerializeField]
	private SpriteRenderer hoverRendered;
	[SerializeField]
	private Tile tileData;
	public Tile TileData { get { return tileData; } }

	private Vector2Int Position { get { return tileData.Position; } }
	private int Height { get { return tileData.Height; } }

    public void SetupTile(Vector2Int position, string type, int height = 1)
    {
		managerUI = BattleUIManager.Instance;
		tileData = new Tile(position, type, height);
		TilePositioner.PositionTile(transform, position.x, position.y);
		TilePositioner.PositionCollider(GetComponent<BoxCollider>(), Height);
		SetupHover();
    }

	public void SetupHover()
	{
		GameObject hover = Instantiate(managerUI.TileGridPrefab);
		hover.transform.SetParent(transform);
		hover.transform.position = new Vector3(Position.x, (Height * 0.5f) + 0.01f, Position.y);
		hoverRendered = hover.GetComponent<SpriteRenderer>();
		hoverRendered.enabled = false;
	}

	private void OnMouseEnter()
	{
		//manager.TileHover(position);
		//checking if empty to rework
		bool isTileEmpty = false;
		try
		{
			manager.GetUnit(Position);
		}
		catch(System.ArgumentNullException)
		{
			isTileEmpty = true;
		}
		if(!isTileEmpty)
		{
			hoverRendered.color = Color.blue;
		}
		hoverRendered.enabled = true;
	}

	private void OnMouseExit() 
	{
		hoverRendered.color = Color.white;
		hoverRendered.enabled = false;
	}
}
