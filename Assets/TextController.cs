using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;


	// Use this for initialization
	void Start () {
		text.text = "Hello World";
	}

	#region Game State 
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			text.text = "asdf asdf asdf saf sasadfsf w asdf sas asasdf, " + 
						"sfsadf asfas  af asfasas asf asf";
		}
	}
	#endregion
}
