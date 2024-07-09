using UnityEngine;

/**
 *  ICharacter represents variables and functions that all Character implementations need.
 */
public interface ICharacter : IComponent
{
    // Represents a scaler for the character's movement speed
    float MovementSpeed { get; }
    // Represents the current health of a character
    float Health { get; set; }
    // Represents the defense of a character (lowers the damage they take)
    float Defense { get; }
    // Chracters need to implement their own move logic
    void Move();
    // Characters need to implement their own attack logic
    void Attack();
    // Chracters need to be able to identify if they have died
    bool isAlive();

}

/**
 *  Character is an abstract class that represents a specific character a Player can choose.
 *  Character is responsible for unique motion implementations, display, health, etc.
 */
public abstract class Character : MonoBehaviour, ICharacter
{
    // SerializeField allows us to edit private variables in Unity (e.g. it is listed for us to edit despite being private)
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _defense;

    // Implementations of interface functions and variables
    public Component component { get { return this; } }
    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public float Defense
    {
        get { return _defense; }
    }
    // Custom motion implementation for each character
    public abstract void Move();
    // Custom attack implementation for each character
    public abstract void Attack();
    public bool isAlive()
    {
        return _health <= 0;
    }
}
