using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//  TODO: REFACTOR A BIT
public class Enemy : ControllableCharacter
{
    private EntityManager pm;
    // TODO: FIGURE OUT THESE VARIABLES IN AN OOP WAY
    [SerializeField]
    private float cooldown = 1f;
    private float shootTimer = 0f;
    private ProgressBar healthBar;
    public override void Awake()
    {
        base.Awake();
        pm = GameManager.instance.PlayerList;
        // Add a health bar for the enemy
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ProgressBar");
        GameObject b1 = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        healthBar = b1.GetComponent<ProgressBar>();
        indicators.Add(healthBar);
    }
    private bool lookAhead()
    {
        if(!character)
        {
            return false;
        }
        // We want to be able to hit player and map
        int layermask = LayerMask.GetMask("Player","Wall");
        // Casts out the ray and stores its output in "hit"
        RaycastHit2D hit = Physics2D.Raycast(character.transform.position, character.transform.right, this.character.Vision,layermask);
        if(hit.collider != null)
        {
            // Make sure the ray hit a player
            return hit.collider.gameObject.layer == Layers.PLAYER;
        }
        return false;
    }
    public override void Update()
    {
        if (character)
        {
            // Check if character is dead
            if (!character.isAlive())
            {
                this.Terminate();
                return;
            }
            // TODO: AI Pathfinding control, walk towards player
            // Put the item ner the character
            character.HoldItem();
            // Put the health bar near the player & update it
            healthBar.transform.position = character.transform.position + Vector3.down*1.3f;
            healthBar.UpdateAmount(character.Health, character.MaxHealth);
            // Find closest player
            Transform closest = null;
            IList<Transform> players = pm.GetLocations();
            foreach (Transform t in players)
            {
                if (closest == null && Vector3.Distance(t.position,character.transform.position) <= character.Vision)
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
                // SHOOT IF THE PATH IS UNOBSTRUCTED
                if(lookAhead())
                {
                    // We count up: player must be in view for 1s
                    shootTimer += Time.deltaTime;
                } else
                {
                    shootTimer = 0f;
                }
                if(shootTimer > cooldown)
                {
                    character.UseItem();
                    shootTimer = 0f;
                }
            }
        }
    }
}
