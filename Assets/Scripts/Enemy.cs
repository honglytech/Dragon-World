using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

// https://unity3d.com/learn/tutorials/topics/scripting/interfaces
public interface IBeast
{
    // Sample test using interface
    // Method and property have to be defined in the class below in order to use with interface
    void Shout();
    string Description { get; set; }
}

// Enemy class is inherited from Character class 
public class Enemy : Character, IBeast 
{
	public string Description { get; set; }

    // Override a vitual method from character class
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        UIController.OnEnemyUpdate(this);
        Debug.Log("Only happens on enemy! not character class");
    }

    public void Shout()
    {

    }

    public override void Die()
	{
		Debug.Log ("Enemy died");
	    Energy = MaximunEnergy;
	    Encounter.OnEnemyDie();
    }
}
