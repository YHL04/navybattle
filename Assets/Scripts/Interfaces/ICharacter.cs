using System.Collections;
using System.Collections.Generic;
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
    // Characters need to hold ammo
    int Ammo { get; }
    // Chracters need to implement their own move logic
    void Move(float dx, float dy);
    // Characters need to take damage
    void TakeDamage(float damage);
    // Chracters need to be able to identify if they have died
    bool isAlive();
    // Apply buffs to the current character
    void Upgrade(float hp, float defense, float movementSpeed);
    // Heal the character some amount
    void Heal(float hp);
    // Reload the charactere's ammo
    void StockAmmo(int ammo);
    // Terminate the character gameobject
    void Terminate();

    // NOTE: Not every character needs an inventory or be able to use items!
}