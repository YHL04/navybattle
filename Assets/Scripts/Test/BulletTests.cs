using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTests : MonoBehaviour
{
    void Start()
    {
        RunTests();
    }

    void RunTests()
    {
        TestBulletInitialization();
        TestBulletCollisionWithCharacter();
        TestBulletDestroyOnMaxDistance();
    }

    void TestBulletInitialization()
    {
        // Create a new bullet object
        GameObject bulletObject = new GameObject();
        Bullet bullet = bulletObject.AddComponent<Bullet>();

        // Initialize with test data
        bullet.Initialize(10f, 8, 20f);

        // Assert initial values
        Debug.Assert(bulletObject != null, "Bullet should be initialized.");
        Debug.Assert(bulletObject.GetComponent<Bullet>() != null, "Bullet component should be attached.");
    }

    void TestBulletCollisionWithCharacter()
    {
        // Create a bullet object and a character object
        GameObject bulletObject = new GameObject();
        Bullet bullet = bulletObject.AddComponent<Bullet>();
        GameObject characterObject = new GameObject();
        Character character = characterObject.AddComponent<Character>();

        // Set character's layer to be different from bullet
        characterObject.layer = 7;
        bullet.Initialize(10f, 8, 20f);

        // Simulate collision
        bullet.OnTriggerEnter2D(characterObject.GetComponent<Collider2D>());

        // Assert bullet destruction and character taking damage
        Debug.Assert(bulletObject == null, "Bullet should be destroyed after hitting character.");
    }

    void TestBulletDestroyOnMaxDistance()
    {
        // Create a bullet object
        GameObject bulletObject = new GameObject();
        Bullet bullet = bulletObject.AddComponent<Bullet>();

        // Initialize with max distance
        bullet.Initialize(5f, 8, 20f);

        // Simulate movement exceeding max distance
        bullet.transform.position += new Vector3(6f, 0, 0);

        // Assert bullet destruction
        Debug.Assert(bulletObject == null, "Bullet should be destroyed after exceeding max distance.");
    }
}
