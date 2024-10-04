using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapUnit : MapEntity
{
	private string unitName;

	public void SetupUnit(int x, int y, int height, MapDisplayManager manager, string name)
	{
		SetupEntity(x, y, height, manager);
		unitName = name;
	}

	protected override void OnMouseEnter()
	{
		base.OnMouseEnter();
		Debug.Log(unitName);
	}

    public void DisplayUnit()
	{
		//
	}
}
