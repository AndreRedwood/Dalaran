using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
	private static BattleManager battleManager = BattleManager.GetInstance();

	[SerializeField]
	private GameObject tileColliderPrefab;
	[SerializeField]
	private GameObject tileHoverPrefab;
	[SerializeField]
	private GameObject tileHover = null;

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
    }

    public void DisplayTile(int x, int y)
    {
		string[] tileInfo = battleManager.GetTile(x, y).GetDisplayInformation();
		tileNameLabel.text = dictionaty[tileInfo[0]];
		tileImage.sprite = GetComponent<TileAtlas>().PullSprite(tileInfo[0]);
		tileHeightLabel.text = $"Height: {tileInfo[1]}";
		tileMoveCostLabel.text = $"Move Cost: {tileInfo[2]}";
		CreateTileHover(x, y, battleManager.GetTile(x, y).Height);
    }

	private void CreateTileHover(int x, int y, int height)
	{
		Destroy(tileHover);
		tileHover = Instantiate(tileHoverPrefab);
		tileHover.transform.position = new Vector3(x, (height * 0.5f) + 0.01f, y);
	}

	[Header("Language")]
	[SerializedDictionary("Key", "Text")][SerializeField]
	private SerializedDictionary<string, string> dictionaty;
}
