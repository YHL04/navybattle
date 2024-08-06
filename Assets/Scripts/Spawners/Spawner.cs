using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : ScriptableObject
{
    public abstract GameObject spawn(Vector3 location);
}

public abstract class EntitySpawner : MonoBehaviour
{
    protected Spawner spawner;
    [SerializeField]
    protected EntityManager manager;
}
