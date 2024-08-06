using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLocation : LocationSpawner
{
   public override void Awake()
    {
        SniperSpawner ss = ScriptableObject.CreateInstance<SniperSpawner>();
        ss.Initialize();
        this.spawner = ss;
    }
}
