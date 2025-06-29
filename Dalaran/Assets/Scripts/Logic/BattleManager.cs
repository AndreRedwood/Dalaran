using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BattleManager
{
    private BattleManager () { }

	private static BattleManager instance;

	public static BattleManager GetInstance()
	{
		if (instance == null)
		{
			instance = new BattleManager();
		}
		return instance;
	}

	private Tile[,] map;

	public void SetMap(string[,] mapData)
	{
		int mapWidth = mapData.GetLength(0);
		int mapHeight = mapData.GetLength(1);

		map = new Tile[mapWidth, mapHeight];
		for (int x = 0; x < mapWidth; x++)
		{
			for (int y = 0; y < mapHeight; y++)
			{
				string newTileData = mapData[x, y];
				int newTileHeight = (int)char.GetNumericValue(newTileData[0]);
				newTileData = newTileData.Remove(0, 1);
				map[x, y] = new Tile(x, y, newTileData, newTileHeight);
			}
		}
	}

	private List<Unit> units = new List<Unit>();

	//temporary, to do actual setting up units
	public void SetUnits()
	{
		units.Add(new Unit("Grenadier", 100, 17, "XX", 10, new int[] { 1, 2, }, new string[] { "", "" }));
		units[0].SetPosition(new Vector2Int(0, 4));
	}

	public Tile GetTile(int x, int y)
	{
		return map[x, y];
	}

	public Unit GetUnit(Vector2Int position)
	{
		foreach (Unit unit in units) 
		{
			if(unit.Position == position)
			{
				return unit;
			}
		}
		throw new System.ArgumentNullException($"No Unit on {position}");
	}
}
