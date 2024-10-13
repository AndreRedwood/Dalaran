using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
	private string name;
	public string Name { get { return name; } }
	private string unitClass;
	public string UnitClass { get { return unitClass; } }
	
	public int x { private set; get; }
	public int y { private set; get; }

	public int ActionPoints { private set;  get; }

	public int Health { private set; get; }
	private int maxHealth;
	public int MaxHealth { get { return maxHealth; } }

	private int armor;
	public int Armor { get {  return armor; } }
	public string ArmorClass { private set; get; }

	private int dodge;
	private int Dodge { 
		get 
		{ 
			return dodge + BattleManager.GetInstance().GetTile(x, y).DodgeModifier;
		} 
	}
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

	public void SetPosition(int x, int y)
	{
		this.x = x; 
		this.y = y;
	}

	public void ResetActionPoints()
	{
		ActionPoints = 8;
	}
}
