using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
	[SerializeField]
	private GameObject tileObject;
	[SerializeField]
	private int x, y;
	[SerializeField]
	private int tileHeight;

    void Awake()
    {
		transform.position = new Vector3(x, 0f, y);
        tileObject = transform.GetChild(0).gameObject;
		TilePositioner.PositionTile(tileObject.transform, tileHeight);
    }

	private void OnMouseEnter()
	{
		tileObject.GetComponent<MeshRenderer>().material.color = Color.red;
	}

	private void OnMouseExit()
	{
		tileObject.GetComponent<MeshRenderer>().material.color= Color.white;
	}
}
