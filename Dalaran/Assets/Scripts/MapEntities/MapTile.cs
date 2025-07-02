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

	public bool IsHovered;
	private bool IsEmpty { get { return manager.IsTileEmpty(Position); } }
	//to improve, as tile may be occupied by sometning else than Unit
	private bool IsSelected 
	{
		get 
		{
			if(manager.IsTileEmpty(Position)) return false;
			return manager.SelectedUnit == manager.GetUnit(Position) ? true : false; 
		} 
	}
	private bool isHighlighted;

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

	public void RefreshHover()
	{
		if(IsHovered) 
		{
			if (!IsEmpty)
			{
				if (IsSelected)
				{
					hoverRendered.color = new Color32(0, 71, 171, 255);
				}
				else
				{
					hoverRendered.color = new Color32(100, 149, 237, 255);
				}
			}
			else
			{
				hoverRendered.color = Color.white;
			}
			hoverRendered.enabled = true;
		}
		else if (IsSelected)
		{
			hoverRendered.color = new Color32(100, 149, 237, 255);
			hoverRendered.enabled = true;
		}
		else
		{
			hoverRendered.enabled = false;
		}
	}

	private void OnMouseEnter()
	{
		IsHovered = true;
		RefreshHover();
	}

	private void OnMouseExit() 
	{
		IsHovered = false;
		RefreshHover();
		//hoverRendered.color = Color.white;
		//hoverRendered.enabled = false;
	}
}
