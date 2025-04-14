using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class MapLoader
{
	private static string LoadMapRAW(string mapID)
	{
		StreamReader sr = new StreamReader(Application.dataPath + "/Maps/" + mapID + "/data.map");
		string output = sr.ReadToEnd();
		sr.Close();
		return output;
	}

	public static string[,] LoadMap(string mapID)
	{
		string rawData = LoadMapRAW(mapID);
		string[] rows = rawData.Split(new char[] { ';' });
		string[] exampleRow = rows[0].Split(new char[] { '.' });
		string[,] output = new string[rows.Length, exampleRow.Length];
		for (int x = 0; x < rows.Length; x++) 
		{
			rows[x] = rows[x].Trim();
			string[] row = rows[x].Split(new char[] { '.' });
			for (int y = 0; y < row.Length; y++) 
			{
				output[x, y] = row[y].Trim();
			}
		}
		return output;
	}
}
