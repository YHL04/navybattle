using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Soldier is an implementation of a Character. A "Player" will contain this GameObject via composition and 
// call its logic functions within its control loops (Update).
public class Soldier : Character
{
    public override void Attack()
    {

    }

    public override void Move()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(dx*MovementSpeed, dy*MovementSpeed);
    }
}
