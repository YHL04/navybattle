using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawnerButton : MonoBehaviour
{
    [SerializeField]
    private int count;
    private AmmoSpawner ammoSpawner;
    // Update is called once per frame
    void Awake()
    {
        ammoSpawner = ScriptableObject.CreateInstance<AmmoSpawner>();
        ammoSpawner.Initialize(count);
    }
    void OnMouseDown()
    {
        ammoSpawner.spawn(new Vector3(5f, 0f, 0f));
    }
}
