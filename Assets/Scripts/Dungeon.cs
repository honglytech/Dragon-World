using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

// Dungeon class contains a constructor that creates a randm dungeon for gameplay.
public class Dungeon
{

	#region Property
	// Property chest that can be assigned to and randomly creates itself to the Dungeon
	public Chest Chest { get; set; }
	public Enemy Enemy { get; set; }
	public bool Exit { get; set; }
	public bool Empty { get; set; }
	public Vector2 DungeonIndex { get; set; }
	#endregion

	// Constructor for creating a random dungeon
	public Dungeon()
	{
		// Create a random dice roll to decide what to do next based on a range
		int roll = Random.Range(0, 20);
		// when roll is greater than 0 and less than 5, the enemy will appear 
		if (roll > 0 && roll < 6)
		{
			// Get a random enemy from enemy database
			Enemy = EnemyDatabase.Instance.GetRandomEnemy(); 
			// Set the dungeon for enemy
			Enemy.DungeonIndex = DungeonIndex;
		} else if (roll > 8 && roll < 13)
		{
			// Create a new object called Chest and stores in Chest using constructor 
			Chest = new Chest ();
		} else {
			Empty = true;
		}
	}

	// Overload constructor for specific dungeons
	public Dungeon(Chest chest, Enemy enemy, bool empty, bool exit)
	{		
		// Pass the parameters to this constructor and assign them to Dungeon
		this.Chest = chest;
		this.Enemy = enemy;
		this.Empty = empty;
		this.Exit = exit;
	}
		

}
