using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<string> Inventory { get; set; }
    #endregion  

}
