using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;
using System.IO;

public class Player : Character
{
    string path;
    string jsonString;

    public int Floor { get; set; }
    // Track current player location
    public Dungeon CurrentLocation { get; set; }
    // Can be accessible in the inspector 
    [SerializeField]
    Encounter encounter;
    public DragonWorld world;

    // Use this for initialization
    void Start()
    {

        path = Application.streamingAssetsPath + "/player.json";
        jsonString = File.ReadAllText(path);
        PlayerJson gamePlayer = JsonUtility.FromJson<PlayerJson>(jsonString);
        Debug.Log(gamePlayer.Attack);


        // For now, these variables are used for testing 
        //Floor = 0; 
        //Energy = 25;
        //Attack = 15;
        //Defence = 6;
        //Gold = 0;
        Inventory = new List<string>();
        // Current position 
        DungeonIndex = new Vector2(2, 2);
        // Set up the dungeon for navigation and check if it is empty
        //world.Dungeon[(int)DungeonIndex.x, (int)DungeonIndex.y].Empty = true ;
        this.CurrentLocation = world.Dungeon[(int)DungeonIndex.x, (int)DungeonIndex.y];
        this.CurrentLocation.Empty = true;
        AddItem("many items");
    }

    public void Move(int direction)
    {
        // If the current player location has an enemy, then stop execution
        if (this.CurrentLocation.Enemy)
        {
            return;
        }

        /* 
            * Map view as dungeon index 10 x 10
            * the row 0,0 to 9,0 is the dungeon wall
            * the row 0,9 to 9,9 is the dungeon wall
            * the column 0,0 down to 0,0 is the dungeon wall
            * the column 9,0 down to 9,9 is the dungeon wall 
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            | 0(x),0(y) | 1,0 | 2,0 | 3,0 | 4,0 | 5,0 | 6,0 | 7,0 | 8,0 | 9,0 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,1    | 1,1 | 2,1 | 3,1 | 4,1 | 5,1 | 6,1 | 7,1 | 8,1 | 9,1 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,2    | 1,2 | 2,2 | 3,2 | 4,2 | 5,2 | 6,2 | 7,2 | 8,2 | 9,2 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,3    | 1,3 | 2,3 | 3,3 | 4,3 | 5,3 | 6,3 | 7,3 | 8,3 | 9,3 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,4    | 1,4 | 2,4 | 3,4 | 4,4 | 5,4 | 6,4 | 7,4 | 8,4 | 9,4 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,5    | 1,5 | 2,5 | 3,5 | 4,5 | 5,5 | 6,5 | 7,5 | 8,5 | 9,5 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,6    | 1,6 | 2,6 | 3,6 | 4,6 | 5,6 | 6,6 | 7,6 | 8,6 | 9,6 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,7    | 1,7 | 2,7 | 3,7 | 4,7 | 5,7 | 6,7 | 7,7 | 8,7 | 9,7 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,8    | 1,8 | 2,8 | 3,8 | 4,8 | 5,8 | 6,8 | 7,8 | 8,8 | 9,8 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            |    0,9    | 1,9 | 2,9 | 3,9 | 4,9 | 5,9 | 6,9 | 7,9 | 8,9 | 9,9 |
            +-----------+-----+-----+-----+-----+-----+-----+-----+-----+-----+
            */

        // y coordinate must be greater than 0 so that player can move north
        // says if the player is at 2,2, then to go up or north, it is required to subtract one        
        if (direction == 0 && DungeonIndex.y > 0)
        {
            // Move north
            Journal.Instance.Log("You move north");
            DungeonIndex -= Vector2.up;
        }
        if (direction == 1 && DungeonIndex.x < world.Dungeon.GetLength(0) - 1)
        {
            // Move east
            Journal.Instance.Log("You move east");
            DungeonIndex += Vector2.right;
        }
        // Since the size of the dungeon is dynamic that is not fixed (can be changed
        // by the grid in the world generator), check to see if the y coordinator is less than
        // specific dimension of the array; the y value. y value is 1 while x value is 0.
        // then subtract by -1 since GetLength would result in 10 in this case rather than 0 to 9.        
        if (direction == 2 && DungeonIndex.y < world.Dungeon.GetLength(1) - 1)
        {
            // Move south
            Journal.Instance.Log("You move south");
            DungeonIndex -= Vector2.down;
        }
        if (direction == 3 && DungeonIndex.x > 0)
        {
            // Move west
            Journal.Instance.Log("You move west");
            DungeonIndex += Vector2.left;
        }

        // After player has moved, then investigate which dungeon the player is in. 
        // Check to see if the current dungeon index is different from player dungeon index (last time)
        if (this.CurrentLocation.DungeonIndex != DungeonIndex)
            DetermineLocation();

    }

    public void DetermineLocation()
    {
        this.CurrentLocation = world.Dungeon[(int)DungeonIndex.x, (int)DungeonIndex.y];
        Debug.Log(DungeonIndex);
        // Disable all dynmaic controls at the start of determine player current location 
        // then start enable relevant buttons only. If the room has enemy, player can only 
        // select fight or flee buttons, but not open chest button, etc. 
        encounter.ResetDynamicControls();

        if (this.CurrentLocation.Empty)
        {
            Journal.Instance.Log("Player is in an empty dungeon!");
        }
        else if (this.CurrentLocation.Chest != null)
        {
            Journal.Instance.Log("Player has found a chest!" + " What do you want to do now?" );
        }
        else if (this.CurrentLocation.Enemy != null)
        {
            Journal.Instance.Log("You face an enemy: " + CurrentLocation.Enemy.Description + " How do you decide now?");
            // Player starts the fight when encounter an enemy
            encounter.StartFight();
        }
        else if (this.CurrentLocation.Exit)
        {
            Journal.Instance.Log("You can exit to the next floor. Do you want to continue?");
        }
    }

    public void AddItem(string item)
    {
        Journal.Instance.Log("You were given: " + item);
        // Add item to the list 
        Inventory.Add(item);
    }

    public void AddItem(int item)
    {
        Inventory.Add(ItemDatabase.Instance.Items[item]);
    }

    
    public override void TakeDamage(int amount)
    {
        Debug.Log("Player override TakeDemage");
        base.TakeDamage(amount);
    }

    public override void Die()
    {
        Debug.Log("Player, Game over!");
        base.Die();
    }
}

[System.Serializable]
public class PlayerJson
{
    public int Floor;
    public int Energy;
    public int Attack;
    public int Defence;
    public int Gold;
}

