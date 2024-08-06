using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

// Soldier is an implementation of a Character. A "Player" will contain this GameObject via composition and 
// call its logic functions within its control loops (Update).
public class JohnNavyBattle : Character
{
    // SET DEFAULT VALUES HERE
    private const float defaultSpeed = 4f;
    private const float defaultHealth = 10000f;
    private const float defaultDefense = 50f;

    // CONSTRUCTOR PASSES IN BUFF VALUES
    void Awake()
    {
        this._movementSpeed = defaultSpeed;
        this._health = defaultHealth;
        this._maxHealth = defaultHealth;
        this._defense = defaultDefense;
        this._ammo = 64;
        this._inventory = new IInventoryItem[5];
    }
}
