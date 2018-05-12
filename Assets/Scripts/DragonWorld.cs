using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

// DragonWorld is a class that generates dungeons and creates the grids for gameplay.
public class DragonWorld : MonoBehaviour
{

	// 2D array 
	public Dungeon[,] Dungeon { get; set; }
	public Vector2 Grid; 

	private void Awake()
	{
		// Grid with 4 columns and 6 rows 
		// Dungeon = new Dungeon[4, 6];

		// Casting for floats (.x and .y) to integers
		Dungeon = new Dungeon[(int)Grid.x, (int)Grid.y];
		StartCoroutine(GenerateFloor()); 
	}

	// Floor that lays out the dungeons and creates the grids 
	/* Coroutines: When calling a function, it runs to completion before returning. 
	   This effectively means that any action taking place in a function must happen within a single frame update; 
	   a function call can’t be used to contain a procedural animation or a sequence of events over time.
	   https://docs.unity3d.com/Manual/Coroutines.html */
	/* A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes.
	   https://docs.unity3d.com/ScriptReference/Coroutine.html */
	// Coroutine uses IEnumerator keyword that can go through one step at a time.
	public IEnumerator GenerateFloor()
	{
		// Create a coordinate system using nested loops
		// Grid.x is now 10 columns as defined in Unity's Inspector of DragonWorld 
		Debug.Log("Generating floor!");
		for(int x = 0; x < Grid.x; x++)
		{
			// Grid.y is rows 
			for(int y = 0; y < Grid.y; y++)
			{
				// Randomly generate new dungeons using the constructor from Dungeon class 
				// A first floor of the dungeon is created 
				Dungeon[x, y] = new Dungeon
				{
					// Initialise properties within the object 
					DungeonIndex = new Vector2(x,y)
				};
			}
		}

		// Return the enumerator value that requires to add to coroutine and checks every single frame.
		// Create a new object for yield instruction to wait for 4 seconds before continue execution below codes.
		Debug.Log("Finding exit that takes seconds!" + Time.time);
		yield return new WaitForSeconds(4);

		// Create a exit for the next floor using local method 
		// Random positions for exit 
		Vector2 exitDungeon = new Vector2((int)Random.Range(0, Grid.x), (int)Random.Range(0, Grid.y)); 

		// Set the dungeon with all coordinates to be an exit 
		Dungeon[(int)exitDungeon.x, (int)exitDungeon.y].Exit = true;
		Dungeon[(int)exitDungeon.y, (int)exitDungeon.y].Empty = false;
		Debug.Log ("Exit is at: " + exitDungeon + " " + Time.time); 
	}

    // Sample examples of how to call the GenerateFloor method 
    // Example #1: generate new floor for player class
    // player.world.GenerateFloor(); 
    // Example #2: generate new floor for Enemy class to stay in various dungeons, waiting for the player
    // Enemy.world.GenerateFloor();

}