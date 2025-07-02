using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
	private BattleUIManager() { }
	private static BattleUIManager instance;
	public static BattleUIManager Instance 
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<BattleUIManager>();
				Debug.Log(instance.gameObject.name);
			}
			return instance;
		}
	}
	//refactor this bloody singleton


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Debug.Log(instance.gameObject.name);
		}
		else
		{
			if(instance != this) 
			{
				Destroy(gameObject);
			}
		}
	}

	public static BattleManager battleManager = BattleManager.GetInstance();

	[SerializeField]
	private GameObject testEntity;

	[SerializeField]
	public GameObject tileColliderPrefab;
	[SerializeField]
	private GameObject tileHoverPrefab;
	[SerializeField]
	private GameObject tileHover = null;
	[SerializeField]
	private GameObject tileGridPrefab;
	public GameObject TileGridPrefab { get { return tileGridPrefab; } }
	[SerializeField]
	private List<GameObject> hoverGrid = new List<GameObject>();

	[Header("Left Panel")]
	[SerializeField] private TextMeshProUGUI selectedNameLabel;
	[SerializeField] private Image selectedImage;
	[SerializeField] private Slider selectedHealthBar;

	[Header("Right Panel")]
	[SerializeField] private TextMeshProUGUI tileNameLabel;
	[SerializeField] private TextMeshProUGUI tileMoveCostLabel;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;
	[SerializeField] private TextMeshProUGUI tileDetailsLabel;
	[SerializeField] private TextMeshProUGUI turnLabel;

	void Start()
    {
		Debug.Log(Instance.gameObject.name);
		string[,] mapData = MapLoader.LoadMap("001");
		for(int x = 0; x < mapData.GetLength(0); x++) 
		{
			for(int y = 0; y < mapData.GetLength(1); y++) 
			{
				string newTileData = mapData[x, y];
			}
		}
		battleManager.SetMap(mapData);
		//here loading and creating unit from prefab
		testEntity.GetComponent<Unit>().SetupUnit(this, "grenadier", 100, 5, 10, 5, new Vector2Int(0, 4));
		battleManager.SetUnits(testEntity.GetComponent<Unit>());
    }

    private void DisplayTile(Vector2Int position)
    {
		string[] tileInfo = battleManager.GetTile(position).GetDisplayInformation();
		tileNameLabel.text = dictionaty[tileInfo[0]];
		tileImage.sprite = GetComponent<TileAtlas>().PullSprite(tileInfo[0]);
		tileHeightLabel.text = $"Height: {tileInfo[1]}";
		tileMoveCostLabel.text = $"Move Cost: {tileInfo[2]}";
    }

	//probably out
	public void TileHover(Vector2Int position)
	{
		int height = battleManager.GetTile(position).Height;
		Destroy(tileHover);
		tileHover = Instantiate(tileHoverPrefab);
		tileHover.transform.position = new Vector3(position.x, (height * 0.5f) + 0.01f, position.y);
		DisplayTile(position);
	}

	public void UnitSelect(Vector2Int position)
	{
		selectedNameLabel.text = battleManager.GetUnit(position).Name;
	}

	[Header("Language")]
	[SerializedDictionary("Key", "Text")][SerializeField]
	private SerializedDictionary<string, string> dictionaty;
}
