using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntity : MonoBehaviour
{
	[SerializeField]
	protected BattleUIManager manager;
	[SerializeField]
	protected Vector2Int position;
	public Vector2Int Position { get { return position; } }

	public void SetupEntity(BattleUIManager manager, Vector2Int position)
	{
		this.manager = manager;
		this.position = position;
		SetPosition(position);
	}

	public void SetPosition(Vector2Int newPosition)
	{
		position = newPosition;
		int height = BattleManager.GetInstance().GetTile(Position).Height;
		EntityPositioner.PositionEntity(transform, position.x, position.y, height);
	}

	//move to unit
	protected virtual void OnMouseEnter()
	{
		manager.UnitHover(position);
	}

	protected virtual void OnMouseExit()
	{
		manager.UnitUnhover();
	}

	private void OnMouseDown()
	{
		Debug.Log("SELECT!");
		manager.UnitSelect(position);
		//Select unit and ignore its collider until unselected
		//Display its name and some basic stats
		//Generate movement grid from map <- function should be in unit, so it could modify move costs
		//Move speed and check how many tiles it moved and if it can move again
	}
}
