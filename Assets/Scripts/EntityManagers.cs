using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityManager : MonoBehaviour
{

    [SerializeField]
    private List<ControllableCharacter> players;
    // Gets an immutable list of all current locations
    public IList<Transform> GetLocations()
    {
        List<Transform> t = new List<Transform>();
        foreach (ControllableCharacter p in players)
        {
            if(p.ActiveCharacter)
            {
                t.Add(p.GetLocation());
            }
        }
        return t.AsReadOnly();
    }
    // Update loop to terminate zombie players
    public void Update()
    {
        players.RemoveAll(x => !x.Active);
    }
    public void AddPlayer(ControllableCharacter cr)
    {
        if (cr != null)
        {
            cr.gameObject.layer = this.gameObject.layer;
            players.Add(cr);
        }
    }
    // Get size of the current list that is ALIVE
    public int getSize()
    {
        int count = 0;
        foreach(ControllableCharacter c in players)
        {
            if(c.ActiveCharacter)
            {
                count++;
            }
        }
        return count;
    }
}