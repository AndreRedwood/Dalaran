using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
	[Header("Right Panel")]
	[SerializeField] private TextMeshProUGUI tileNameLabel;
	[SerializeField] private TextMeshProUGUI tileMoveCostLabel;
	[SerializeField] private TextMeshProUGUI tileHeightLabel;
	[SerializeField] private Image tileImage;
	[SerializeField] private TextMeshProUGUI tileDetailsLabel;
	[SerializeField] private TextMeshProUGUI turnLabel;

	// Start is called before the first frame update
	void Start()
    {
		string[,] mapData = MapLoader.LoadMap("001");
		Debug.Log(mapData[1, 2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
