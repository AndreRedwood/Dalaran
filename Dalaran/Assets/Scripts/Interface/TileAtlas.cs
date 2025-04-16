using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAtlas : MonoBehaviour
{
	[SerializedDictionary("Key", "Sprite")] [SerializeField]
	private SerializedDictionary<string, Sprite> atlas;

	public Sprite PullSprite(string type)
	{
		return atlas[type];
	}
}
