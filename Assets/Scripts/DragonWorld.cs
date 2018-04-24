using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

public class DragonWorld : MonoBehaviour {

	// 2D array 
	public Dungeon[,] Dungeon { get; set; }
	public Vector2 Grid; 

	private void Awake(){
		// Grid with 4 columns and 6 rows 
		// Dungeon = new Dungeon[4, 6];

		// Casting for floats (.x and .y) to integers
		Dungeon = new Dungeon[(int)Grid.x, (int)Grid.y];
		GenerateFloor(); 
	}

	// Floor that lays out the dungeons and creates the grids 
	public void GenerateFloor(){
		// Create a coordinate system using nested loops
		// Grid.x is now 10 columns as defined in Unity's Inspector of DragonWorld 
		for(int x = 0; x < Grid.x; x++){
			// Grid.y is rows 
			for(int y = 0; y < Grid.y; y++){
				// Randomly generate new dungeons using the constructor from Dungeon class 
				// A first floor of the dungeon is created 
				Dungeon [x, y] = new Dungeon {
					// Initialise properties within the object 
					DungeonIndex = new Vector2 (x, y)
				};
			}
		}

		// Create a exit for the next floor using local method 
		// Random positions for exit 
		Vector2 exitDungeon = new Vector2((int)Random.Range(0, Grid.x), (int)Random.Range(0, Grid.y)); 

		// Set the dungeon with all coordinates to be an exit 
		Dungeon[(int)exitDungeon.x, (int)exitDungeon.y].Exit = true;
		Dungeon[(int)exitDungeon.x, (int)exitDungeon.y].Empty = false;
		Debug.Log ("Exit is at: " + exitDungeon); 
	}
}
