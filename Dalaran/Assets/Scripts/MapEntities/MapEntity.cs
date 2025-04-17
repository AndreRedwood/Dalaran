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
		manager.DisplayUnitSelect(x, y);
	}
}
