using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;
using System.IO;

// Dragon class is inherited from Enemy class that loads data from JSON file.
public class EvilSpirit : Enemy
{
	string path;
	string jsonString;

	// Use this for initialization
	void Start () {

		path = Application.streamingAssetsPath + "/evilSpirit.json"; 
		jsonString = File.ReadAllText(path);
	    EvilSpiritJson evilSpiritDragon = JsonUtility.FromJson<EvilSpiritJson>(jsonString);

		// For now, these variables are used for testing 
		Gold = evilSpiritDragon.Gold;
		Debug.Log(Gold);
		Description = "Evil Spirit";
	    MaximunEnergy = 10;
		//Attack = 4;
		//Defence = 3;
		//Gold = 20;
		Inventory.Add ("Eyes");
	}
}

[System.Serializable]
public class EvilSpiritJson
{
	public int Energy;
	public int Attack;
	public int Defence;
	public int Gold;
}