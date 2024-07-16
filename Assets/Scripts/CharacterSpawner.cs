using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : ScriptableObject
{
    // Note we don't need more subclasses as Unity takes care of this for us with SerializeField, and all instantiation has the SAME logic!

    // Instantiate the prefab and provide this character to the player
    public void spawnCharacter(Player player, GameObject prefab, Vector3 location)
    {
        GameObject g =  Instantiate(prefab, location, Quaternion.identity);
        player.setCharacter(g.GetComponent<Character>());
    }
}
