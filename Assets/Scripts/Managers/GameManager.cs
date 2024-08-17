using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EntityManager enemies;
    [SerializeField]
    private EntityManager players;
    [SerializeField]
    private Camera mainCamera;
    public static GameManager instance;
    Scene currentScene;
    public GameObject Canvas;
    bool Paused = false;


    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    public EntityManager EnemyList { get { return enemies; } }
    public EntityManager PlayerList { get { return players; } }
    public Camera Camera { get { return mainCamera; } }

    // GAME LOGIC LOOP
    public void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                Canvas.gameObject.SetActive(false);

                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                Canvas.gameObject.SetActive(true);
                Paused = true;
            }
        }


        if (players.getSize() == 0)
        {
            SceneManager.LoadScene(5);
            Debug.Log("PLAYERS LOST");
        }
        if (enemies.getSize() == 0)
        {
            if (currentScene.name == "Level3")
            {
                SceneManager.LoadScene(4);
            }
            else if (currentScene.name == "Level1")
            {
                SceneManager.LoadScene(2);
            }
            else if (currentScene.name == "Level2")
            {
                SceneManager.LoadScene(3);
            }

            Debug.Log("EMEMIES LOST");
        }
    }
}