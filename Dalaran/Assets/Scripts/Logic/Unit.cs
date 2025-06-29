using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Unit
{
	private string name;
	public string Name { get { return name; } }
	private string unitClass;
	public string UnitClass { get { return unitClass; } }

	[SerializeField] private Vector2Int position;
	public Vector2Int Position { get { return position; } }

	public int ActionPoints { private set;  get; }

	public int Health { private set; get; }
	private int maxHealth;
	public int MaxHealth { get { return maxHealth; } }

	private int armor;
	public int Armor { get {  return armor; } }
	public string ArmorClass { private set; get; }

	private int dodge;
	private int skillRanged;
	private int SkillRanged { get { return skillRanged; } }
	private int skillMelee;
	public int SkillMelee { get { return skillMelee; } }

	private string[] weapons;
	public string[] Weapons { get {  return weapons; } }

	public Unit(string name, int health, int armor, string armorClass, int dodge, int[] skill, string[] weapons)
	{
		this.name = name;
		maxHealth =  health;
		Health = health;
		this.armor = armor;
		ArmorClass = armorClass;
		this.dodge = dodge;
		skillRanged = skill[0];
		skillMelee = skill[1];
		this.weapons = weapons;
		ResetActionPoints();
	}

	public void SetPosition(Vector2Int newPosition)
	{
		position = newPosition;
	}

	public void ResetActionPoints()
	{
		ActionPoints = 8;
	}
}
