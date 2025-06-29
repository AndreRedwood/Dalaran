using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainAtlas
{
	//to rework into modular library of scriptable objects
	public static int GetMovementCost(string id)
	{
		switch(id)
		{
			case "MU":
			case "WS": return 3;
			case "WD": return 99;
			default: return 2;
		}
	}

	public static string GetTerrainName(string id)
	{
		switch(id) 
		{
			case "GR": return "grass";
			case "RD": return "road";
			case "MD": return "mud";
			case "WS": return "water_shallow";
			default: return null;
		}
	}
}
