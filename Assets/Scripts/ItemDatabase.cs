using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

public class ItemDatabase : MonoBehaviour {

	// new List<string>() is an auto implementing property 
	// that is allowed to use with .net 4.6 of C# 6.0
	public List<string> Items { get; set; } = new List<string>();

	// Create static reference to the instance as a part of the instance
	// This will store items and then reference it (read only property)
	// Static keyword is now used for this purpose
	// Reference from ItemDatabase.Instance
	// Can only use set within ItemDatabase 
	public static ItemDatabase Instance { get; private set; }

	// This method will be called before start method is called 
	private void Awake()
	{
		// Check to see if instance is not empty, meaning instance is assigned an ItemDatabase
		// And also check to see ItemDatabase that is assigned is not this instance of the ItemDatabase
		// Meaning there are two copies, if this happens, delete it 
		if (Instance != null && Instance != this)
			Destroy (this.gameObject);
		else			
			Instance = this;

		Items.Add ("Crown");
		Items.Add ("Cinderella Glass Shoes");
	}
}
