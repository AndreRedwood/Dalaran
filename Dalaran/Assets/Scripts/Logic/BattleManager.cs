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

	public Tile GetTile(int x, int y)
	{
		return map[x, y];
	}
}
