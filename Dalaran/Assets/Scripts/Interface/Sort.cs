using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Sort : MonoBehaviour
{
	private const int IsometricRangePerUnit = 100;
	[SerializeField]
	public int height;

	private void Update()
	{
		Renderer renderer = GetComponent<Renderer>();
		renderer.sortingOrder = -(int) transform.position.y - height * IsometricRangePerUnit;
	}
}
