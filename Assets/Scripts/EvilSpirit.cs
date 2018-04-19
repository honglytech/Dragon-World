using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

// Dragon class is inherited from Enemy class 
public class EvilSpirit : Enemy {
	
	// Use this for initialization
	void Start () {
		Energy = 10;
		Attack = 4;
		Defence = 3;
		Gold = 20;
		Inventory.Add ("Eyes");
	}
}
