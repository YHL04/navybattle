using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Refactor to this at some point
public abstract class ButtonSpawner : EntitySpawner
{
    [SerializeField]
    private Vector3 location;
    // Update is called once per frame
    public abstract void Awake();
    void OnMouseDown()
    {
        spawner.spawn(location);
    }
}
