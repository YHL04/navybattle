using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField]
    private Player p;
    [SerializeField]
    private GameObject soldier;
    [SerializeField]
    private GameObject defaultGun;
    // Update is called once per frame
    void Awake()
    {
        characterSpawner = ScriptableObject.CreateInstance<CharacterSpawner>();
        itemSpawner = ScriptableObject.CreateInstance<ItemSpawner>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            characterSpawner.spawnCharacter(p, soldier, new Vector3(0f, 0f, 0f));

        }
    }
}
