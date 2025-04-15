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
				GameObject newTile = GameObject.Instantiate(tileColliderPrefab);
				newTile.GetComponent<MapTile>().SetupTile(this, x, y, (int)char.GetNumericValue(newTileData[0]));
			}
		}
		battleManager.SetMap(mapData);
    }

    public void DisplayTile(int x, int y)
    {
		string[] tileInfo = battleManager.GetTile(x, y).GetDisplayInformation();
		tileNameLabel.text = tileInfo[0];
		tileHeightLabel.text = tileInfo[1];
		tileMoveCostLabel.text = tileInfo[2];
    }
}
