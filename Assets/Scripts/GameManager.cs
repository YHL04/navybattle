using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layers
{
    public const int UI = 5;
    public const int PLAYER = 6;
    public const int ENEMY = 7;
    public const int ITEM = 8;
    public const int MAP = 9;
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EntityManager enemies;
    [SerializeField]
    private EntityManager players;
    [SerializeField]
    private Camera mainCamera;
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public EntityManager EnemyList { get { return enemies; } }
    public EntityManager PlayerList { get {return players; } }
    public Camera Camera { get { return mainCamera; } }

    // GAME LOGIC LOOP
    public void Update()
    {
        if(players.getSize() == 0)
        {
            Debug.Log("PLAYERS LOST");
        }
        if(enemies.getSize() == 0)
        {
            Debug.Log("EMEMIES LOST");
        }
    }
}