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
	}

	public void AddItem(string item)
	{
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