using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
	private string name;
	public string Name { get { return name; } }
	
	public int x { private set; get; }
	public int y { private set; get; }

	public int ActionPoints { private set;  get; }

	private string armor;
	public string Armor { get {  return armor; } }

	private string[] weapons;
	public string[] Weapons { get {  return weapons; } }

	public Unit(string name, string armor, string[] weapons)
	{
		this.name = name;
		this.armor = armor;
		this.weapons = weapons;
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
