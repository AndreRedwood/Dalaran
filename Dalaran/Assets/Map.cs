using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int mapWidth, mapHeight;
	[SerializeField] private int[,] map;
	[SerializeField] private GameObject tilePrefab;

	private void Awake()
	{
		map = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 1 }, { 0, 1, 1, 2, 1 }, { 0, 0, 1, 2, 1 }, { 0, 1, 1, 1, 1 } };
		GenerateMap(map);
	}

	private void GenerateMap(int[,] map)
	{
		for(int x = 0; x < mapWidth; x++)
		{
			for( int y = 0; y < mapHeight; y++) 
			{
				float xOffset = x * 0.5f + y * -0.5f;
				float yOffset = x * 0.25f + y * 0.25f;
				GameObject tile = Instantiate(tilePrefab, new Vector3(xOffset, yOffset, 0), Quaternion.identity);
				tile.GetComponent<Tile>().SetHeight(map[x,y]);
			}
		}
	}
}
