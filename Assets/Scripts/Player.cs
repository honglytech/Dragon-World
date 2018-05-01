using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;
using System.IO;

public class Player : Character
{
    string path;
    string jsonString;

    public int Floor { get; set; }
	// Track current player location
	public Dungeon CurrentLocation { get; set; }
	// Can be accessible in the inspector 
	[SerializeField]
	DragonWorld world; 

	// Use this for initialization
	void Start () {

		path = Application.streamingAssetsPath + "/player.json"; 
		jsonString = File.ReadAllText(path);
		playerJson gamePlayer = JsonUtility.FromJson<playerJson>(jsonString);
		Debug.Log(gamePlayer.Attack);


		// For now, these variables are used for testing 
		//Floor = 0; 
		//Energy = 25;
		//Attack = 15;
		//Defence = 6;
		//Gold = 0;
		Inventory = new List<string> ();
		DungeonIndex = new Vector2 (2, 2);
		// Set up the dungeon for navigation 
		world.Dungeon[(int)DungeonIndex.x, (int)DungeonIndex.y].Empty = true;
		AddItem("A lot of items");
	}

	public void Move(int direction)
	{
		// If the current player location has an enemy, then stop execution
		if (this.CurrentLocation.Enemy) 
		{
			return;
		}

		/* 
		 * Map view as dungeon index 10 x 10
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,0 | 1,0 | 2,0 | 3,0 | 4,0 | 5,0 | 6,0 | 7,0 | 8,0 | 9,0 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,1 | 1,1 | 2,1 | 3,1 | 4,1 | 5,1 | 6,1 | 7,1 | 8,1 | 9,1 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,2 | 1,2 | 2,2 | 3,2 | 4,2 | 5,2 | 6,2 | 7,2 | 8,2 | 9,2 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,3 | 1,3 | 2,3 | 3,3 | 4,3 | 5,3 | 6,3 | 7,3 | 8,3 | 9,3 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,4 | 1,4 | 2,4 | 3,4 | 4,4 | 5,4 | 6,4 | 7,4 | 8,4 | 9,4 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,5 | 1,5 | 2,5 | 3,5 | 4,5 | 5,5 | 6,5 | 7,5 | 8,5 | 9,5 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,6 | 1,6 | 2,6 | 3,6 | 4,6 | 5,6 | 6,6 | 7,6 | 8,6 | 9,6 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,7 | 1,7 | 2,7 | 3,7 | 4,7 | 5,7 | 6,7 | 7,7 | 8,7 | 9,7 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,8 | 1,8 | 2,8 | 3,8 | 4,8 | 5,8 | 6,8 | 7,8 | 8,8 | 9,8 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 | 0,9 | 1,9 | 2,9 | 3,9 | 4,9 | 5,9 | 6,9 | 7,9 | 8,9 | 9,9 |
		 +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
		 */

		switch (direction)
		{
			// Move north
			case 0:
			
				break;
			// Move east
			case 1: 
				break;
			// Move south
			case 2:

				break;
			// Move west
			case 3: 
				break;
		}

	}

	public void AddItem(string item)
	{
		Journal.Instance.Log("You were given item: " + item);

		// Add item to the list 
		Inventory.Add (item);
	}

	/*
	public override void TakeDemage(int amount)
	{
		Debug.Log ("Player override TakeDemage");
		//base.TakeDemage (amount);
	}*/

	public override void Die()
	{
		Debug.Log ("Player, Game over!");
		base.Die ();
	}
}

[System.Serializable]
public class playerJson
{
	public int Floor;
	public int Energy;
	public int Attack;
	public int Defence;
	public int Gold;
}