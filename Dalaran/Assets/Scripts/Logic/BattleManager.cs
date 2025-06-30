using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BattleManager
{
    private BattleManager () { }

	private static BattleManager instance = null;

	public static BattleManager GetInstance()
	{
		if (instance == null)
		{
			instance = new BattleManager();
		}
		return instance;
	}

	private BattleUIManager managerUI;

	private MapTile[,] map;
	//merge to MapTile
	//private Tile[,] map;

	public void SetMap(string[,] mapData)
	{
		managerUI = BattleUIManager.Instance;

		int mapWidth = mapData.GetLength(0);
		int mapHeight = mapData.GetLength(1);

		map = new MapTile[mapWidth, mapHeight];
		Debug.Log(managerUI.gameObject.name); //
		for (int x = 0; x < mapWidth; x++)
		{
			for (int y = 0; y < mapHeight; y++)
			{
				string newTileData = mapData[x, y];
				int newTileHeight = (int)char.GetNumericValue(newTileData[0]);
				newTileData = newTileData.Remove(0, 1);
				map[x, y] = GameObject.Instantiate(managerUI.tileColliderPrefab).GetComponent<MapTile>();
				map[x, y].SetupTile(new Vector2Int(x, y), newTileData, newTileHeight);
			}
		}
	}

	private List<Unit> units = new List<Unit>();

	//temporary, to do actual setting up units
	public void SetUnits(Unit testUnit)
	{
		units.Add(testUnit);
		units[0].SetPosition(new Vector2Int(0, 4));
	}

	public MapTile GetMapTile(Vector2Int position)
	{
		return map[position.x, position.y];
	}

	public Tile GetTile(Vector2Int position)
	{
		return map[position.x, position.y].TileData;
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
