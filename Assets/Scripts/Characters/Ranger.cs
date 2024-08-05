using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

// Soldier is an implementation of a Character. A "Player" will contain this GameObject via composition and 
// call its logic functions within its control loops (Update).
public class Ranger : Character
{
    // SET DEFAULT VALUES HERE
    private const float defaultSpeed = 6f;
    private const float defaultHealth = 80f;
    private const float defaultDefense = 3f;

    // CONSTRUCTOR PASSES IN BUFF VALUES
    void Awake()
    {
        this._movementSpeed = defaultSpeed;
        this._health = defaultHealth;
        this._maxHealth = defaultHealth;
        this._defense = defaultDefense;
        this._ammo = 32;
        this._inventory = new IInventoryItem[5];
    }
}
