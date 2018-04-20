using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

public class Player : Character {

	public int Floor { get; set; }

	// Use this for initialization
	void Start () {
		Floor = 0; 
		Energy = 25;
		Attack = 15;
		Defence = 6;
		Gold = 0;
		Inventory = new List<string> ();
		DungeonIndex = new Vector2 (2, 2);
	}

	public void AddItem(string item)
	{
		// Add item to the list 
		Inventory.Add (item);
	}

	public override void TakeDemage(int amount)
	{
		Debug.Log ("Player override TakeDemage");
		base.TakeDemage (amount);
	}

	public override void Die()
	{
		Debug.Log ("Player, Game over!");
		base.Die ();
	}
}
