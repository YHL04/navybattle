using System;
using Unity.VisualScripting;
using UnityEngine;

/**
 *  ICharacter represents variables and functions that all Character implementations need.
 */
public interface ICharacter : IComponent
{
    // Represents a scaler for the character's movement speed
    float MovementSpeed { get; }
    // Represents the current health of a character
    float Health { get; }
    // Represents the total health
    float MaxHealth { get; }
    // Represents the defense of a character (lowers the damage they take)
    float Defense { get; }
    // Represents the layer the character is in (Player, Enemy) to determine damage groups
    int Layer { get; set; }
    // Chracters need to implement their own move logic
    void Move(float dx, float dy);
    // Characters need to implement their own attack logic
    void Attack();
    // Characters need to take damage
    void TakeDamage(float damage);
    // Chracters need to be able to identify if they have died
    bool isAlive();
    // Apply buffs to the current character
    void Upgrade(float hp, float defense, float movementSpeed);
    // Heal the character some amount
    void Heal(float hp);
    // Terminate the character gameobject
    void Terminate();

}

/**
 *  Character is an abstract class that represents a specific character a Player can choose.
 *  Character is responsible for unique motion implementations, display, health, etc.
 */
public abstract class Character : MonoBehaviour, ICharacter
{
    // SerializeField allows us to edit private variables in Unity (e.g. it is listed for us to edit despite being private)
    protected float _movementSpeed;
    protected float _maxHealth;
    protected float _health;
    protected float _defense;
    protected int _layer;

    // Implementations of interface functions and variables
    public Component component { get { return this; } }
    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }
    public float Health
    {
        get { return _health; }
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    public float Defense
    {
        get { return _defense; }
    }
    public int Layer
    {
        get { return _layer; }
        set { _layer = value; }
    }
    // Every character has the same move logic
    public void Move(float dx, float dy)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(dx * MovementSpeed, dy * MovementSpeed);
    }
    // Every character will have the same attack logic, just with a different weapon
    public void Attack()
    {
        throw new NotImplementedException("Method not implemented.");
    }
    // Every character will take damage by the same algorithm
    public void TakeDamage(float damage)
    {
        // This function can change... about every 2 defense will half the damage taken. Note we clamp with 0
        this._health = Mathf.Clamp(this.Health - damage / (0.5f * this.Defense + 1), 0, float.MaxValue);
    }
    // Check if the character is alive
    public bool isAlive()
    {
        return _health <= 0;
    }
    // Upgrade the character's stats
    public void Upgrade(float hp, float defense, float movementSpeed)
    {
        this._maxHealth = hp;
        this._defense = defense;
        this._movementSpeed = movementSpeed;
    }
    // Heal the character
    public void Heal(float hp)
    {
        this._health = Mathf.Clamp(this.Health + hp, 0, this.MaxHealth);
    }
    // Terminate the current character GameObject
    public void Terminate()
    {
        Destroy(this);
    }
}
