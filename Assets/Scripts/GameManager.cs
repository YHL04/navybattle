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
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public EntityManager EnemyList { get { return enemies; } }
    public EntityManager PlayerList { get {return players; } }
}