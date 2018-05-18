using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;
using System.IO;

// Dragon class is inherited from Enemy class that uses load data from JSON file.
public class Dragon : Enemy
{
    string path;
	// Represent raw JSON data
	string jsonString;

	// The method will load once the class is called.
	void Start ()
	{	
		// Store the path of JSON data file 
		path = Application.streamingAssetsPath + "/dragon.json"; 
		// Read all blocks of texts from JSON file 
		jsonString = File.ReadAllText(path);
        // Pass dragonJson type so that JSON file knows which type it is working with
	    DragonJson gameDragon = JsonUtility.FromJson<DragonJson>(jsonString);

	    MaximunEnergy = 20;
		Description = "Dragon";
		Inventory.Add ("Wing");
	}
}

// Create a class to map the JSON data to
[System.Serializable]
public class DragonJson
{
	// Using variable rather than property since System.Serializable supports only variable
	public int Energy;
	public int Attack;
	public int Defence;
	public int Gold;
}