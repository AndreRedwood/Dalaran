using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Unit : MapEntity
{
	[SerializeField]
	private string unitName;
	public string Name { get { return unitName; } }

	[SerializeField]
	private int[] health = new int[2];
	public int Health { get { return health[0]; } }
	public int MaxHealth { get { return health[1]; } }

	[SerializeField]
	private int[] guard = new int[2];
	public int Guard { get { return guard[0]; } }
	public int MaxGuard { get { return guard[1]; } }

	[SerializeField]
	private int armor;
	public int Armor { get {  return armor; } }

	[SerializeField]
	private int[] movement = new int[2];
	public int Movement { get { return movement[0]; } }
	public int MaxMovement { get { return movement[1]; } }

	public void SetupUnit(BattleUIManager manager, string name, int health, int guard, int armor, int movement, Vector2Int position)
	{
		SetupEntity(manager, position);
		unitName = name;
		this.health[0] = this.health[1] = health;
		this.guard[0] = this.guard[1] = guard;
		this.armor = armor;
		this.movement[0] = this.movement[1] = movement;
	}
}
