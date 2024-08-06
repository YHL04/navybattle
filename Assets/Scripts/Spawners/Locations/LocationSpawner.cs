using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public abstract class LocationSpawner : EntitySpawner
{
    // Abstract setting of spawner for each location type
    public abstract void Awake();
    public void Start()
    {
        // Load Prefabs for Player and Enemy
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        // Spawn the character
        GameObject obj = spawner.spawn(this.transform.position);
        Character c = obj.GetComponent<Character>();
        // Get the correct ControllabeCharacter (player or enemy)
        GameObject cc = null;
        int layer = manager.gameObject.layer;
        if(layer == Layers.PLAYER)
        {
            cc = Instantiate(playerPrefab, this.transform.position, Quaternion.identity);
        } else if (layer == Layers.ENEMY)
        {
            cc = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        }
        // Build this character
        ControllableCharacter entity = cc.GetComponentInParent<ControllableCharacter>();
        entity.setCharacter(c);
        // Add character to the manager
        this.manager.AddPlayer(entity);
    }
}
