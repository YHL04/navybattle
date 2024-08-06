using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperSpawnerButton : MonoBehaviour
{
    [SerializeField]
    private ControllableCharacter p;
    private SniperSpawner sniperSpawner;
    // Update is called once per frame
    void Awake()
    {
        sniperSpawner = ScriptableObject.CreateInstance<SniperSpawner>();
        sniperSpawner.Initialize();
    }
    void OnMouseDown()
    {
        GameObject g = sniperSpawner.spawn(new Vector3(0f, 0f, 0f));
        Character c = g.GetComponent<Character>();
        p.setCharacter(c);
    }
}
