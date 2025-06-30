using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TerrainType
{
	grass,
	road,
	mud,
	shallow_water,
	deep_water
}

[Serializable]
public class Tile
{
	[SerializeField]
	private Vector2Int position;
	public Vector2Int Position { get { return position; } }
	[SerializeField]
	private int height;
	public int Height { get { return height; } }

	private string typeID;
	public int MoveCost { get { return TerrainAtlas.GetMovementCost(typeID); } }
	public string Type { get { return TerrainAtlas.GetTerrainName(typeID); } }

	private int dodgeModifier;
	public int DodgeModifier { get { return dodgeModifier;} }

	//probably rework Type into prefab template for greater control
	public Tile(Vector2Int position, string type, int height)
	{
		this.position = position;
		typeID = type;
		this.height = height;
	}

	public string[] GetDisplayInformation()
	{
		return new string[] { TerrainAtlas.GetTerrainName(typeID), height.ToString(), MoveCost.ToString() };
	}
}
