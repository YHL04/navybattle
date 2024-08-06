using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierLocation : LocationSpawner
{
    public override void Awake()
    {
        SoldierSpawner ss = ScriptableObject.CreateInstance<SoldierSpawner>();
        ss.Initialize();
        this.spawner = ss;
    }
}