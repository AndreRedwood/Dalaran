using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapDisplayManager : MonoBehaviour
{
    [SerializeField] private int mapWidth, mapHeight;
	[SerializeField] private int[,] mapHeights;
	[SerializeField] private string[,] mapTypes;
	[SerializeField] private GameObject tilePrefab;

	[SerializedDictionary("Key", "Sprite")] [SerializeField]
	private SerializedDictionary<string, Sprite> Atlas;

	private Tile[,] map;
	[SerializeField] private TextMeshProUGUI tileLabel;
	[SerializeField] private TextMeshProUGUI tileDescr;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;

	private void Awake()
	{
		mapHeights = new int[8, 8] { 
			{ 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 2, 2, 1, 0, 0 }, 
			{ 0, 1, 1, 2, 2, 1, 0, 0 }, 
			{ 0, 0, 1, 2, 1, 1, 0, 1 }, 
			{ 2, 1, 1, 1, 1, 1, 1, 1 },
			{ 2, 1, 1, 1, 1, 1, 0, 1 },
			{ 1, 1, 0, 0, 1, 0, 0, 2 },
			{ 1, 1, 0, 0, 0, 0, 1, 2 }
		};
		mapTypes = new string[8, 8] {
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Mud", "Mud", "ShallowWater" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass", "Mud", "ShallowWater" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass" , "ShallowWater", "ShallowWater" },
			{ "Road", "Road", "Grass", "Grass", "Grass", "Grass", "DeepWater", "Grass" },
			{ "Grass", "Road", "Road", "Road", "Road", "Road", "Bridge", "Road" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "Grass", "DeepWater", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "ShallowWater", "ShallowWater", "Grass" },
			{ "Grass", "Grass", "Grass", "Grass", "Grass", "ShallowWater", "Grass", "Grass" }
		};
		GenerateMap(mapHeights, mapTypes);
	}

	private void GenerateMap(int[,] heights, string[,] types)
	{
		map = new Tile[mapWidth, mapHeight];
		for(int x = 0; x < mapWidth; x++)
		{
			for( int y = 0; y < mapHeight; y++) 
			{
				Sprite sprite = Atlas[$"{types[x, y]}Height{heights[x, y] + 1}"];
				float xOffset = x * 0.5f + y * -0.5f;
				float yOffset = x * 0.25f + y * 0.25f;
				GameObject tile = Instantiate(tilePrefab, new Vector3(xOffset, yOffset, 0), Quaternion.identity);
				tile.GetComponent<MapTile>().SetupTile(new int[2] { x, y}, heights[x,y], sprite, this);
				tile.name = $"Tile {x},{y}";
				map[x, y] = new Tile(x, y, types[x,y], heights[x,y]+1);
			}
		}
	}

	public void DisplayTileInfo(int x, int y)
	{
		string[] info = map[x, y].GetDisplayInformation();
		tileLabel.text = info[0];
		tileDescr.text = $"Movement cost: {info[2]}";
		tileHeightLabel.text = info[1];
		if (info[0] != "Bridge")
		{
			tileImage.sprite = Atlas[$"{info[0]}Height1"];
		} else
		{
			tileImage.sprite = Atlas["BridgeHeight2"];
		}
		//tileImage.SetNativeSize();
	}
}
