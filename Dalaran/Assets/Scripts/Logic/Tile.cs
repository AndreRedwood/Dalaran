using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
	private int x, y;
	private int height;
	private string type;
	private int movementCost;

	public Tile(int x, int y, string type, int height = 1, int movementCost = 2)
	{
		this.x = x;
		this.y = y;
		this.type = type;
		this.height = height;
		this.movementCost = movementCost;
	}

	public string[] GetDisplayInformation()
	{
		return new string[] { type, height.ToString(), movementCost.ToString() };
	}
}
