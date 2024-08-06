using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//  TODO: REFACTOR A BIT
public class Enemy : ControllableCharacter
{
    private EntityManager pm;
    // TODO: FIGURE OUT THESE VARIABLES IN AN OOP WAY
    [SerializeField]
    private float range;
    [SerializeField]
    private float cooldown = 1f;
    private float time = 0f;
    public void Start()
    {
        pm = GameManager.instance.PlayerList;
    }
    public override void Update()
    {
        time += Time.deltaTime;
        if (character)
        {
            // Check if character is dead
            if (!character.isAlive())
            {
                character.Terminate();
                character = null;
                // If the character is dead, the Enemy goes into a "Zombie" state until the EnemyManager deletes us.
                this.active = false;
                return;
            }
            // TODO: AI Pathfinding control, walk towards player
            character.HoldItem();
            // Find closest player
            Transform closest = null;
            IList<Transform> players = pm.GetLocations();
            foreach (Transform t in players)
            {
                if (closest == null && Vector3.Distance(t.position,character.transform.position) <= range)
                {
                    closest = t;
                }
            }
            // If we are currently tracking a player in view...
            if (closest != null)
            {
                // AIM
                Vector3 dir = closest.position - character.transform.position;
                float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                character.transform.rotation = Quaternion.Euler(0, 0, rotZ);
                // SHOOT
                if(time > cooldown)
                {
                    character.UseItem();
                    time = 0;
                }
            }
        }
    }
}
