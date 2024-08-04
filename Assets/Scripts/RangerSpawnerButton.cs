using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rangerSpawnerButton : MonoBehaviour
{
    [SerializeField]
    private ControllableCharacter p;
    private RangerSpawner rangerSpawner;
    // Update is called once per frame
    void Awake()
    {
        rangerSpawner = ScriptableObject.CreateInstance<RangerSpawner>();
        rangerSpawner.Initialize();
    }
    void OnMouseDown()
    {
        GameObject g = rangerSpawner.spawn(new Vector3(0f, 0f, 0f));
        Character c = g.GetComponent<Character>();
        p.setCharacter(c);
    }
}