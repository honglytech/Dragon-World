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

    
    void Start () {
		
	}
    
    public void ResetDynamicControls()
    {
        // Loop through fight dynamic buttons 
        foreach (Button button in dynamicControls)
        {
            // Disable all dynamic controls (fight, run, exit & open chest)
            button.interactable = false;
        }
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

    // Enable open chest button when encounter open chest 
    public void OpenChest()
    {        
        dynamicControls[3].interactable = true;
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


}
