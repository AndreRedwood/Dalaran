using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapUnit : MapEntity
{
	private string unitName;

	public void SetupUnit(int x, int y, int height, BattleDisplayManager manager, string name)
	{
		SetupEntity(x, y, height, manager);
		SetPosition(x, y, height);
		unitName = name;
	}

	protected override void OnMouseEnter()
	{
		base.OnMouseEnter();
		battleDisplayManager.DisplayUnitInfo();
	}

	protected override void OnMouseExit()
	{
		base.OnMouseExit();
		battleDisplayManager.UnHoverUnit();
	}
}
