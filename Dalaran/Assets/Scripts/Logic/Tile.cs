using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
	private int x, y;
	private int height;
	private string type;
	private int movementCost;

	public Tile(int x, int y, string type, int height = 1)
	{
		this.x = x;
		this.y = y;
		this.type = type;
		this.height = height;
		switch(type)
		{
			case "Mud":
			case "Shallow_Water": movementCost = 3; break;
			case "Deep_Water": movementCost = 99; break;
			default: movementCost = 2; break;
		}
	}

	public string[] GetDisplayInformation()
	{
		return new string[] { type, height.ToString(), movementCost.ToString() };
	}
}
