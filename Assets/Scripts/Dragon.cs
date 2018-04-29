using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;
using System.IO;

// Dragon class is inherited from Enemy class 
public class Dragon : Enemy
{
	string path;
	string jsonString;

	// Use this for initialization
	void Start ()
	{	
		path = Application.streamingAssetsPath + "/dragon.json"; 
		jsonString = File.ReadAllText(path);
		dragonJson gameDragon = JsonUtility.FromJson<dragonJson>(jsonString);
		//Debug.Log(gameDragon.Attack);

		// For now, these variables are used for testing 
		//Energy = 20;
		Attack = gameDragon.Attack;
		//Debug.Log(Attack);
		//Defence = 5;
		//Gold = 15;
		Inventory.Add ("Wing");
	}
}

[System.Serializable]
public class dragonJson
{
	public int Energy;
	public int Attack;
	public int Defence;
	public int Gold;
}