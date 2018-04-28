using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextDragonWorldRPG;

public class EnemyDatabase : MonoBehaviour
{

	// Enemies is a list of type enemy and the objects can be Dragon and EvilSpirit
	// which are objects that are classes that inherit from enemy (polymorphism)
	public List<Enemy> Enemies { get; set; } = new List<Enemy>();
	public static EnemyDatabase Instance { get; set; }

	private void Awake()
	{
		Instance = this;

		// Loop through enemy component
		// can be Dragon or EvilSpirit
		foreach (Enemy enemy in GetComponents<Enemy>()) 
		{
			Debug.Log("Enemy found!");
			Enemies.Add (enemy);
			// use this 
			//Enemies.AddRange (GetComponent<Enemy>());
		}

	}

	public Enemy GetRandomEnemy()
	{
		return Enemies[Random.Range(0, Enemies.Count)];
	}

}
