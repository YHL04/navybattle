using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTests : MonoBehaviour
{
    void Start()
    {
        RunTests();
    }

    void RunTests()
    {
        TestPlayerMovement();
        TestPlayerItemUse();
        TestPlayerHealthManagement();
    }

    void TestPlayerMovement()
    {
        // Create a player object and mock necessary components
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        GameObject characterObject = new GameObject();
        Character character = characterObject.AddComponent<Character>();

        // Assign the character to the player
        player.character = character;

        // Simulate movement input
        InputAction.CallbackContext context = new InputAction.CallbackContext();
        context.ReadValue<Vector2>(); // Mock a vector value if needed
        player.Move(context);

        // Assert movement vector is correctly set
        Debug.Assert(playerObject.transform.position != Vector3.zero, "Player should have moved.");
    }

    void TestPlayerItemUse()
    {
        // Create a player object and mock necessary components
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        GameObject characterObject = new GameObject();
        Character character = characterObject.AddComponent<Character>();

        // Assign the character to the player
        player.character = character;

        // Mock an item in the inventory (assuming inventory system is in place)
        // Simulate item use
        InputAction.CallbackContext context = new InputAction.CallbackContext();
        player.UseItem(context);

        // Assuming you have logic to decrease ammo or affect health:
        // You would need to check the expected outcome here.
        // For now, I'll assume some item usage impacts the player's state.
        Debug.Assert(character.Ammo == character.MaxHealth - 1, "Player should have used an item.");
    }

    void TestPlayerHealthManagement()
    {
        // Create a player object and mock necessary components
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        GameObject characterObject = new GameObject();
        Character character = characterObject.AddComponent<Character>();

        // Assign the character to the player
        player.character = character;

        // Simulate damage
        character.TakeDamage(10f);

        // Assert health reduction
        Debug.Assert(character.Health < character.MaxHealth, "Player should have taken damage.");
    }
}
