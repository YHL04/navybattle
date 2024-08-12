using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * EntitySpawner is a special type of spawner that can be attatched to a GameObject. 
 * This is the abstract class for everything relating to spawning entities like Player and Enemy.
 */
public abstract class EntitySpawner : MonoBehaviour
{
    protected Spawner spawner;
    [SerializeField]
    protected EntityManager manager;
}
