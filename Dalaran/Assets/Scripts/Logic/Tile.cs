using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
	private int x, y;
	private int height;
	public int Height { get { return height; } }
	private string type;
	private int movementCost;

	private int dodgeModifier;
	public int DodgeModifier { get { return dodgeModifier;} }

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
		switch (type)
		{
			case "Mud":
			case "Shallow_Water": dodgeModifier = -10; break;
			default: dodgeModifier = 0; break;
		}
	}

	public string[] GetDisplayInformation()
	{
		return new string[] { type, height.ToString(), movementCost.ToString() };
	}
}
