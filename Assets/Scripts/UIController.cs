using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextDragonWorldRPG;

// This UIController class will define events for the UI 
public class UIController : MonoBehaviour {

    [SerializeField]
    Player player;
    [SerializeField]
    Text playerStatsText, enemyStatsText, playerItemsText; 
    // Delegate is to define a method signature as a type. This type is used to create method-variables. 
    public delegate void OnPlayerUpdateHandler();
    public static OnPlayerUpdateHandler OnPlayerStatChange;
    public static OnPlayerUpdateHandler OnPlayerItemsChange;

    public delegate void OnEnemyUpdateHandler(Enemy enemy);
    public static OnEnemyUpdateHandler OnEnemyUpdate;
    // Use this for initialization
    void Start () {
        // UpdatePlayerStats and UpdatePlayerItems are the listeners 
        // Add the two listeners to OnPlayerUpdateHandler 
        OnPlayerStatChange += UpdatePlayerStats;
        OnPlayerItemsChange += UpdatePlayerItems;

        // Add the UpdateEnemyStats listener to OnEnemyUpdateHandler  
        OnEnemyUpdate += UpdateEnemyStats;
    }

    public void UpdatePlayerStats()
    {
        playerStatsText.text = string.Format("Player: {0} energy, {1} attack, {2} defence, {3}g", 
            player.Energy, player.Attack, player.Defence, player.Gold);
    }

    public void UpdatePlayerItems()
    {
        playerItemsText.text = "Items: ";
        foreach (string item in player.Inventory)
        {
            playerItemsText.text += item + " / ";
        }
    }

    public void UpdateEnemyStats(Enemy enemy)
    {
        if (enemy)
            enemyStatsText.text = string.Format("{0}: {1} energy, {2} attack, {3} defence", 
                enemy.Description, enemy.Energy, enemy.Attack, enemy.Defence);
        else
        // when there is no enemy, no information about enemy is displayed
            enemyStatsText.text = "";
    }
}
