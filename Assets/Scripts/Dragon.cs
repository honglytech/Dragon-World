using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

// Dragon class is inherited from Enemy class 
public class Dragon : Enemy {
	
	// Use this for initialization
	void Start () {	

		Energy = 20;
		Attack = 8;
		Defence = 5;
		Gold = 15;
		Inventory.Add ("Wing");
	}
}
