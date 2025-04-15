using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TilePositioner
{
	public static void PositionTile(Transform tileTransform, int x, int y)
    {
		tileTransform.position = new Vector3(x, 0f, y);
	}

	public static void PositionCollider(BoxCollider tileCollider, int height)
	{
		tileCollider.size = new Vector3(1f, (height + 1) * 0.5f, 1f);
		tileCollider.center = new Vector3(0f, (height - 1) * 0.25f, 0f);
	}
}
