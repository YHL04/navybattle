using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableCharacter : MonoBehaviour
{
    public Character character;
    protected int hotkey;
    protected bool active;
    protected List<ProgressBar> indicators = new List<ProgressBar>();
    // Check if the current player is active (flag for removal)
    public bool Active { get { return active;  } }
    public bool ActiveCharacter { get { return character != null; } }
    public virtual void Awake()
    {
        this.hotkey = 0;
        this.active = true;
    }
    // How updating occurs depends on the implementation. Controller class
    public abstract void Update();
    public void setCharacter(Character c)
    {
        if (this.character != null)
        {
            this.character.Terminate();
        }
        this.character = c;
        this.character.SetLayer(this.gameObject.layer);
    }
    // Terminating the entity, maybe a player quits or an enemy dies
    public void Terminate()
    {
        if(this.character != null)
        {
            this.character.Terminate();
        }
        foreach(ProgressBar p in indicators) {
            p.Destroy();
        }
        Destroy(this.gameObject);
    }
    // Get the current location of the player's character (if playing)
    public Transform GetLocation()
    {
        if(character != null)
        {
            return character.transform;
        }
        return null;
    }
}