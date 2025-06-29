using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
	public static BattleManager battleManager = BattleManager.GetInstance();

	[SerializeField]
	private GameObject testEntity;

	[SerializeField]
	private GameObject tileColliderPrefab;
	[SerializeField]
	private GameObject tileHoverPrefab;
	[SerializeField]
	private GameObject tileHover = null;
	[SerializeField]
	private GameObject tileGridPrefab;
	[SerializeField]
	private List<GameObject> moveGrid = new List<GameObject>();

	[Header("Right Panel")]
	[SerializeField] private TextMeshProUGUI tileNameLabel;
	[SerializeField] private TextMeshProUGUI tileMoveCostLabel;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;
	[SerializeField] private TextMeshProUGUI tileDetailsLabel;
	[SerializeField] private TextMeshProUGUI turnLabel;

	void Start()
    {
		string[,] mapData = MapLoader.LoadMap("001");
		for(int x = 0; x < mapData.GetLength(0); x++) 
		{
			for(int y = 0; y < mapData.GetLength(1); y++) 
			{
				string newTileData = mapData[x, y];
				GameObject newTile = Instantiate(tileColliderPrefab);
				newTile.GetComponent<MapTile>().SetupTile(this, x, y, (int)char.GetNumericValue(newTileData[0]));
			}
		}
		battleManager.SetMap(mapData);
		//here loading and creating unit from prefab
		testEntity.GetComponent<MapEntity>().SetupEntity(this, 0, 4);
    }

    private void DisplayTile(Vector2Int position)
    {
		string[] tileInfo = battleManager.GetTile(position.x, position.y).GetDisplayInformation();
		tileNameLabel.text = dictionaty[tileInfo[0]];
		tileImage.sprite = GetComponent<TileAtlas>().PullSprite(tileInfo[0]);
		tileHeightLabel.text = $"Height: {tileInfo[1]}";
		tileMoveCostLabel.text = $"Move Cost: {tileInfo[2]}";
    }

	public void TileHover(Vector2Int position)
	{
		int height = battleManager.GetTile(position.x, position.y).Height;
		Destroy(tileHover);
		tileHover = Instantiate(tileHoverPrefab);
		tileHover.transform.position = new Vector3(position.x, (height * 0.5f) + 0.01f, position.y);
		DisplayTile(position);
	}

	public void UnitHover(Vector2Int position)
	{
		int height = battleManager.GetTile(position.x, position.y).Height;
		Destroy(tileHover);
		tileHover = Instantiate(tileGridPrefab);
		tileHover.transform.position = new Vector3(position.x, (height * 0.5f) + 0.01f, position.y);
		DisplayTile(position);

		//foreach (GameObject hover in moveGrid)
		//Destroy(hover);
		//why? mve to actual selection
		//moveGrid = new List<GameObject> { Instantiate(tileGridPrefab) };
		//moveGrid[0].transform.position = new Vector3(position.x, (height * 0.5f) + 0.01f, position.y);
	}

	public void UnitUnhover()
	{
		//Destroy(tileHover);
	}

	[Header("Language")]
	[SerializedDictionary("Key", "Text")][SerializeField]
	private SerializedDictionary<string, string> dictionaty;
}
