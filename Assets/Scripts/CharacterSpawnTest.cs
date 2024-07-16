using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSpawnTest : MonoBehaviour
{
    [SerializeField]
    private Player p;
    [SerializeField]
    private GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CharacterSpawner spawner = ScriptableObject.CreateInstance<CharacterSpawner>();
            spawner.spawnCharacter(p, prefab, new Vector3(0f, 0f, 0f));
        }
    }
}
