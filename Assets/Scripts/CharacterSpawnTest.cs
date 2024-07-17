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
    private CharacterSpawner spawner;
    // Update is called once per frame
    private void Awake()
    {
        spawner = ScriptableObject.CreateInstance<CharacterSpawner>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawner.spawnCharacter(p, prefab, new Vector3(0f, 0f, 0f));
        }
    }
}
