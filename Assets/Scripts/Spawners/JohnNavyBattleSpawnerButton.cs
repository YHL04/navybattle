using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JohnNavyBattleSpawnerButton : MonoBehaviour
{
    [SerializeField]
    private ControllableCharacter p;
    private JohnNavyBattleSpawner johnNavyBattleSpawner;
    // Update is called once per frame
    void Awake()
    {
        johnNavyBattleSpawner = ScriptableObject.CreateInstance<JohnNavyBattleSpawner>();
        johnNavyBattleSpawner.Initialize();
    }
    void OnMouseDown()
    {
        GameObject g = johnNavyBattleSpawner.spawn(new Vector3(0f, 0f, 0f));
        Character c = g.GetComponent<Character>();
        p.setCharacter(c);
    }
}