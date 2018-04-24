using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

public class Chest {

	public string Item { get; set; }
	public int Gold { get; set; }
	// Check to see if it is a trap
	public bool Trap { get; set; }
	// Does it heal or not when open the chest
	public bool Heal { get; set; }
	// If the player wins the fight with enemy, there is a reward with the items the enemy has
	public Enemy Enemy { get; set; }

	// Parameterless Costructor 
	// It handles constructing object on its own based on decision
	public Chest()
	{
		// Create a ramdon float to decide what number to get back
		// From 0 to 4 (a one in 5 chance), check to see a ramdon number if it is number 3
		if (Random.Range (0, 5) == 3) {
			// If true, it is a trap chest
			Trap = true;
		} else if (Random.Range (0, 5) == 3) {			
			Heal = true;
		}
		// One is 6 chance to face an enemy
		else if (Random.Range (0, 6) == 3) {
			// Enemies are defined in their own classes
			// Enemies are collected in EnemyDatabase
			// Enemies[0] is the dragon
			// Enemies[1] is the Evil Spirit
			// Get a ramdon enemy from EnemyDatabase
			Enemy = EnemyDatabase.Instance.Enemies [Random.Range (0, EnemyDatabase.Instance.Enemies.Count)];
		} 
		else 
		{
			// From 0 to all items in ItemDatabase
			// Get the random index
			int itemToAdd = Random.Range (0, ItemDatabase.Instance.Items.Count);
			Item = ItemDatabase.Instance.Items[itemToAdd];
			// Gold can be between 20 and 100
			Gold = Random.Range (20, 100);
		}
	}

}
