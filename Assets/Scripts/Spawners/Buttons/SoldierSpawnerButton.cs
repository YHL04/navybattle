using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierSpawnerButton : MonoBehaviour
{
    [SerializeField]
    private ControllableCharacter p;
    private SoldierSpawner soldierSpawner;
    // Update is called once per frame
    void Awake()
    {
        soldierSpawner = ScriptableObject.CreateInstance<SoldierSpawner>();
        soldierSpawner.Initialize();
    }
    void OnMouseDown()
    {
        GameObject g = soldierSpawner.spawn(new Vector3(0f, 0f, 0f));
        Character c = g.GetComponent<Character>();
        p.setCharacter(c);
    }
}