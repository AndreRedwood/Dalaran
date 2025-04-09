using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TilePositioner
{
	public static void PositionTile(Transform tileTransform, int height)
    {
		tileTransform.localScale = new Vector3(1f, height * 0.5f, 1f);
		tileTransform.localPosition = new Vector3(0f, height * 0.25f, 0f);
	}
}
