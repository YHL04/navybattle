using UnityEngine;

public class EnemyTests : MonoBehaviour
{
    void Start()
    {
        RunTests();
    }

    void RunTests()
    {
        TestEnemyInitialization();
        TestEnemyLookAhead();
        TestEnemyShooting();
    }

    void TestEnemyInitialization()
    {
        // Create an enemy object
        GameObject enemyObject = new GameObject();
        Enemy enemy = enemyObject.AddComponent<Enemy>();

        // Assert enemy initialization
        Debug.Assert(enemy != null, "Enemy should be initialized.");
    }

    void TestEnemyLookAhead()
    {
        // Create an enemy object
        GameObject enemyObject = new GameObject();
        Enemy enemy = enemyObject.AddComponent<Enemy>();

        // Simulate look ahead
        bool canSeePlayer = enemy.lookAhead();

        // Assert look ahead functionality
        Debug.Assert(canSeePlayer == false, "Enemy should not see player if player is not in range.");
    }

    void TestEnemyShooting()
    {
        // Create an enemy object
        GameObject enemyObject = new GameObject();
        Enemy enemy = enemyObject.AddComponent<Enemy>();

        // Simulate player detection and shooting
        enemy.Update();

        // Assert shooting logic
        Debug.Assert(enemy.shootTimer1 > 0f, "Enemy should start shooting if player is detected.");
    }
}
