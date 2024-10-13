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

	public void SetMap(int[,] heights, string[,] types)
	{
		int mapWidth = heights.GetLength(0);
		int mapHeight = heights.GetLength(1);

		map = new Tile[mapWidth, mapHeight];
		for (int x = 0; x < mapWidth; x++)
		{
			for (int y = 0; y < mapHeight; y++)
			{
				map[x, y] = new Tile(x, y, types[x, y], heights[x, y]);
			}
		}
	}

	public Tile GetTile(int x, int y)
	{
		return map[x, y];
	}
}
