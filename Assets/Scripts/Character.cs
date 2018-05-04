using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextDragonWorldRPG
{	
	// Character class is inherited from MonoBehaviour
	public class Character : MonoBehaviour
	{
	    #region Property
	    public int Energy { get; set; }
	    public int Attack { get; set; }
	    public int Defence { get; set; }
	    public int Gold { get; set; }
	    // Vector2 allows to define an X and Y coordinate in 2D array
	    public Vector2 DungeonIndex { get; set; }
	    // Generic list can look for and store any types of objects
		public List<string> Inventory { get; set; } = new List<string>();
	    #endregion  

		// Any classes or objects that inherits from this class can override this method
		// If there is a latest inheritance called, it will use the override of the latest derivative of character
		public virtual void TakeDamage(int amount)
		{
			Energy -= amount; 
			if (Energy <= 0)
			{
			    Die();
			}	
		}

		// Vitrual method can be overridden from a class at inheritance's class
		// Or it can be used as a normal method since it is not being overridden
		public virtual void Die()
		{
			Debug.Log ("Character has died");	
		}
	}
}