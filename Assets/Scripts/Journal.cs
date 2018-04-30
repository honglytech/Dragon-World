using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextDragonWorldRPG;

public class Journal : MonoBehaviour 
{
	// Serialize Text Field
	[SerializeField] Text logText;	
	public static Journal Instance { get; set; }

	// Use this for initialization
	void Awake () 
	{
		// If instance is not null and instance is not assigned to this instance of journal
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
