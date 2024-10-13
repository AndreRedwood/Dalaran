using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

	private Unit unsullied;

	[Header("Left Panel")]
	[SerializeField] private GameObject leftPanel;
	[SerializeField] private TextMeshProUGUI unitNameLabel;
	[SerializeField] private Image unitImage;
	[SerializeField] private TextMeshProUGUI unitHealthLabel;
	[SerializeField] private Slider unitHealthBar;
	[SerializeField] private TextMeshProUGUI weaponLabel;
	[SerializeField] private Image weaponImage;

	[SerializeField] private Sprite unitSprite;

	[Header("Central Panel")]
	[SerializeField] private GameObject centralPanel;
	[SerializeField] private Button attackButton;
	[SerializeField] private TextMeshProUGUI attackCostLabel;
	[SerializeField] private Button[] skillButtons;
	[SerializeField] private TextMeshProUGUI[] skillCostLabels;
	[SerializeField] private Button backpackButton;
	[SerializeField] private Button spellsButton;
	[SerializeField] private Slider actionPointsBar;
	[SerializeField] private TextMeshProUGUI actionPointsLabel;

	[Header("Right Panel")]
	[SerializeField] private TextMeshProUGUI tileNameLabel;
	[SerializeField] private TextMeshProUGUI tileMoveCostLabel;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;
	[SerializeField] private TextMeshProUGUI tileDetailsLabel;
	[SerializeField] private TextMeshProUGUI turnLabel;

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
		BattleManager.GetInstance().SetMap(heights, types);
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
			}
		}
		GameObject unit = Instantiate(testUnit);
		unit.GetComponent<MapUnit>().SetupUnit(testX, testY, testHeight, this, "Unsullied Grenadier");
		unsullied = new Unit( "Unsullied Grenadier", 100, 10, "Heavy", 5, new int[] { 70, 110 }, new string[] { "Axe", "Blunderbuss" } );
		unsullied.SetPosition(testX, testY);
	}

	public void DisplayTileInfo(int x, int y)
	{
		string[] info = BattleManager.GetInstance().GetTile(x, y).GetDisplayInformation();
		tileNameLabel.text = info[0].Replace('_', ' ');
		tileMoveCostLabel.text = $"AP: {info[2]}";
		tileHeightLabel.text = $"Height: {info[1]}";
		tileImage.sprite = tileAtlas.PullSprite(info[0]);
	}

	public void DisplayUnitInfo()
	{
		Unit unit = unsullied; //throw out to argument
		unitNameLabel.text = unit.Name;
		unitImage.sprite = unitSprite;
		unitHealthLabel.text = unit.Health + "/" + unit.MaxHealth;
		unitHealthBar.maxValue = unit.MaxHealth;
		unitHealthBar.value = unit.Health;
		leftPanel.gameObject.SetActive(true);
		//DisplayTileInfo(unit.x, unit.y);
		actionPointsLabel.text = unit.ActionPoints + "/8";
		actionPointsBar.value = unit.ActionPoints;
		centralPanel.gameObject.SetActive(true);
	}

	public void UnHoverUnit()
	{
		leftPanel.gameObject.SetActive(false);
		centralPanel.gameObject.SetActive(false);
	}

	public void HoverTile(int x, int y)
	{
		DisplayTileInfo(x, y);
	}

	public void UnHoverTile()
	{
		//
	}
}
