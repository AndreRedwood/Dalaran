using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityPositioner
{
	private const float entityOffset = 0.2f;
	private const float entityOffsetHeight = 0.55f;

	public static void PositionEntity(Transform entityTransform, int x, int y, int height)
	{
		entityTransform.position = new Vector3(x - entityOffset, 
			((height + 1)*0.5f) - entityOffsetHeight, 
			y - entityOffset);
	}
}
