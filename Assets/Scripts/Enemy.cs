using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG; 

// Enemy class is inherited from Character class 
public class Enemy : Character
{
	public string Description { get; set; }

    // Override a vitual method from character class
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        UIController.OnEnemyUpdate(this);
        Debug.Log("Only happens on enemy! not character class");
    }


    public override void Die()
	{
		Debug.Log ("Enemy died");
	    Energy = MaximunEnergy;
	    Encounter.OnEnemyDie();
    }
}
