using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextDragonWorldRPG;

// Journal class is used in Encounter and Player classes to display information to the player.
public class Journal : MonoBehaviour 
{
	
	// Serialize Text Field
	[SerializeField] Text logText;	
	public static Journal Instance { get; set; }

	// Use this for initialization
	void Awake() 
	{
		// If instance is not null and instance is not assigned to this instance of journal
		// Destroy game object since only one versino is needed. 
		if (Instance != null && Instance != this)
			Destroy (this.gameObject);
		else
			Instance = this;
	}

	// Add text to Scroll View -> Viewpoint -> Content -> Text 
	public void Log(string text)
	{
		logText.text += "\n" + text;
	}
}
