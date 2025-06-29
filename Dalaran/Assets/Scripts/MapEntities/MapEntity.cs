using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntity : MonoBehaviour
{
	[SerializeField]
	private BattleUIManager manager;
	[SerializeField]
	private int x, y;

	public void SetupEntity(BattleUIManager manager, int x, int y)
	{
		this.manager = manager;
		this.x = x;
		this.y = y;
		int height = BattleManager.GetInstance().GetTile(x, y).Height;
		EntityPositioner.PositionEntity(transform, x, y, height);
	}

	private void OnMouseEnter()
	{
		manager.UnitHover(new Vector2Int(x, y));
	}

	private void OnMouseDown()
	{
		Debug.Log("SELECT!");
		//Select unit and ignore its collider until unselected
		//Display its name and some basic stats
		//Generate movement grid from map <- function should be in unit, so it could modify move costs
		//Move speed and check how many tiles it moved and if it can move again
	}
}
