using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerLocation : LocationSpawner
{
    public override void Awake()
    {
        RangerSpawner rs = ScriptableObject.CreateInstance<RangerSpawner>();
        rs.Initialize();
        this.spawner = rs;
    }
}
