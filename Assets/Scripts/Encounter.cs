using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextDragonWorldRPG;

// This encounter class will handle everything happen within the game including attack & flee from enemy (enemy encounter)
// finding an exit (exit encounter) and more.
public class Encounter : MonoBehaviour {

    public Enemy Enemy { get; set; }

    [SerializeField]
    Player player;

    // Create an array of fight controls 
    [SerializeField]
    Button[] dynamicControls;

    // Reference to the method 
    public delegate void OnEnemyDieEventHandler();
    public static OnEnemyDieEventHandler OnEnemyDie;

    void Start ()
    {
        // When calling this event, Prize method is also called on Encounter
        OnEnemyDie += Prize;
    }
    
    public void ResetDynamicControls()
    {
        // Loop through fight dynamic buttons 
        foreach (Button button in dynamicControls)
        {
            // Disable all dynamic controls (fight, run, exit & open chest)
            button.interactable = false;
        }
        dynamicControls[0].interactable = false;
    }

    // When player start fighting, only fight and run buttons are enabled.     
    public void StartFight()
    {
        // Enemy that the player fights with 
        this.Enemy = player.CurrentLocation.Enemy;
        dynamicControls[0].interactable = true;
        dynamicControls[1].interactable = true;
        //UIController.OnEnemyUpdate(this.Enemy);
    }

    // Open chest method to get items and more
    public void OpenChest()
    {
        // Get chest from the current dungeon
        Chest chest = player.CurrentLocation.Chest;
        // Chest is trap, then take 3 damange
        if (chest.Trap)
        {
            player.TakeDamage(3);
            Journal.Instance.Log("This is a trap! You took 3 damage.");
        }
        else if (chest.Heal)
        {
            // Healing player
            player.TakeDamage(-5);
            Journal.Instance.Log("The chest contains 5 healing enery! You gained 5 energy.");
        }
        else if (chest.Enemy)
        {
            // An enemy appears after opening the chest 
            player.CurrentLocation.Enemy = chest.Enemy;
            // Chest is disappeared after opening
            player.CurrentLocation.Chest = null;
            Journal.Instance.Log("The chest contains an enemy. Watch out!");
            // Determines the dungeon right after an enemy appears
            player.DetermineLocation();
        }
        else
        {
            // Player gets gold from opening the chest
            player.Gold += chest.Gold;            
            player.AddItem(chest.Item);
            Journal.Instance.Log("You found: " + chest.Item + " and " + chest.Gold + "g.");
        }
        player.CurrentLocation.Chest = null;
        dynamicControls[3].interactable = false;
    }

    // Enable exit button when the player find an exit 
    public void StartExit()
    {
        dynamicControls[2].interactable = true;
    }

    public void Attack()
    {
        // Get player damange stats 
        // Random.value will give a radom float between 0 and 1 
        int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defence));
        // Get enemy damage stats
        int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
        // 
        Journal.Instance.Log("You attacked, " + playerDamageAmount + " damage!");
        Journal.Instance.Log("Enemy, " + enemyDamageAmount + " damage!");
        // Player take damage from enemy damage
        player.TakeDamage(enemyDamageAmount);
        // Enemy take damage from player damage
        Enemy.TakeDamage(playerDamageAmount);
    }

    // Player runs away from enemy by avoiding the fight 
    public void Run()
    {
        // Multiply player defence by 0.5, meaning player avoids the fight takes less damage amount
        int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defence * .5f)));
        // Enemy disappears
        player.CurrentLocation.Enemy = null;        
        player.TakeDamage(enemyDamageAmount);
        Journal.Instance.Log("You avoid the fight, taking " + enemyDamageAmount + " damage!");
        player.DetermineLocation();
    }

    // Exit floor method 
    public void ExitFloor()
    {
        // When exits the floor, new floor will be generated
        StartCoroutine(player.world.GenerateFloor());
        // add new floor 
        player.Floor += 1;
        Journal.Instance.Log("You found an exit to another floor. Floor: " + player.Floor);
    }

    public void Prize()
    {
        // Get item from enemy to player
        player.AddItem(this.Enemy.Inventory[0]);
        // Get gold from enemy to player 
        player.Gold += this.Enemy.Gold;

        Journal.Instance.Log(string.Format("You've kill {0}. Now look for the dead enemy, you find a {1} and {2} gold!",
            this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold));
        this.Enemy = null;
        // This will show up as an empty dungeon that the player can move again since the enemy is gone. 
        player.DetermineLocation();
    }
}
