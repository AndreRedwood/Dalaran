using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleDisplayManager : MonoBehaviour
{
	[SerializeField] private TileAtlas tileAtlas;

    [SerializeField] private int mapWidth, mapHeight;
	[SerializeField] private int[,] mapHeights;
	[SerializeField] private string[,] mapTypes;
	[SerializeField] private GameObject tilePrefab;

	[SerializeField] private GameObject testUnit;
	[SerializeField] private int testX, testY, testHeight;

	private Tile[,] map;
	private Unit unsullied;
	[SerializeField] private TextMeshProUGUI tileLabel;
	[SerializeField] private TextMeshProUGUI tileDescr;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;

	[SerializeField] private GameObject unitPanel;
	[SerializeField] private TextMeshProUGUI unitLabel;
	[SerializeField] private TextMeshProUGUI unitDescr;
	[SerializeField] private Image unitImage;
	[SerializeField] private Sprite unitSprite;

	private void Awake()
	{
		mapHeights = new int[9, 9] { 
			{ 1, 1, 1, 1, 1, 1, 1, 1, 2 }, 
			{ 1, 1, 1, 3, 3, 2, 1, 1, 1 }, 
			{ 1, 2, 2, 3, 3, 2, 1, 1, 1 }, 
			{ 1, 1, 2, 3, 2, 2, 1, 2, 2 }, 
			{ 3, 2, 2, 2, 2, 2, 2, 2, 2 },
			{ 3, 2, 2, 2, 2, 2, 1, 2, 2 },
			{ 2, 2, 1, 1, 2, 1, 1, 3, 2 },
			{ 2, 2, 1, 1, 1, 1, 2, 3, 3 },
			{ 2, 1, 1, 1, 1, 1, 3, 3, 3 }
		};
		mapTypes = new string[9, 9] {
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Mud", "Mud", "Shallow_Water", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass", "Mud", "Shallow_Water", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass" , "Shallow_Water", "Shallow_Water", "Grass" },
			{ "Road", "Road", "Grass", "Grass", "Grass", "Grass", "Deep_Water", "Grass", "Grass" },
			{ "Grass", "Road", "Road", "Road", "Road", "Road", "Bridge", "Road", "Road" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass", "Deep_Water", "Grass", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Shallow_Water", "Shallow_Water", "Grass", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Shallow_Water", "Grass", "Grass", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Shallow_Water", "Grass", "Grass", "Grass" }
		};
		GenerateMap(mapHeights, mapTypes);
	}

	private void GenerateMap(int[,] heights, string[,] types)
	{
		map = new Tile[mapWidth, mapHeight];
		for (int x = 0; x < mapWidth; x++)
		{
			for (int y = 0; y < mapHeight; y++)
			{
				Sprite sprite = tileAtlas.PullSprite(types[x, y], heights[x, y]);
				float xOffset = x * 0.5f + y * -0.5f;
				float yOffset = x * 0.25f + y * 0.25f;
				GameObject tile = Instantiate(tilePrefab);
				tile.GetComponent<MapTile>().SetupTile( x, y, heights[x, y], sprite, this);
				tile.name = $"Tile {x},{y}";
				map[x, y] = new Tile(x, y, types[x, y], heights[x, y]);
			}
		}
		GameObject unit = Instantiate(testUnit);
		unit.GetComponent<MapUnit>().SetupUnit(testX, testY, testHeight, this, "Unsullied Grenadier");
		unsullied = new Unit( "Unsullied Grenadier", "Heavy", new string[] { "Axe", "Blunderbuss" } );
		unsullied.SetPosition(testX, testY);
	}

	public void DisplayTileInfo(int x, int y)
	{
		string[] info = map[x, y].GetDisplayInformation();
		tileLabel.text = info[0].Replace('_', ' ');
		tileDescr.text = $"Movement cost: {info[2]}";
		tileHeightLabel.text = $"Height: {info[1]}";
		tileImage.sprite = tileAtlas.PullSprite(info[0]);
	}

	public void DisplayUnitInfo()
	{
		Unit unit = unsullied; //throw out to argument
		unitLabel.text = unit.Name;
		unitDescr.text = "Placeholder";
		unitImage.sprite = unitSprite;
		unitPanel.gameObject.SetActive(true);
		//DisplayTileInfo(unit.x, unit.y);
	}

	public void UnHoverUnit()
	{
		unitPanel.gameObject.SetActive(false);
	}

	public void HoverTile(int x, int y)
	{
		DisplayTileInfo(x, y);
	}

	public void UnHoverTile()
	{
		if (selectedTile != null)
			DisplayTileInfo(selectedTile[0], selectedTile[1]);
	}

	private int[] selectedTile;

	public void SelectTile(int x, int y)
	{
		selectedTile = new int[2] { x, y };
	}
}
