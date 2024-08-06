using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float maxDistance;
    private float distance;
    private float damage;
    private int layer;
    private Vector3 lastPos;
    public void Initialize(float dist, int layer, float damage)
    {
        this.maxDistance = dist;
        this.layer = layer;
        this.damage = damage;
    }
    // Set initial location
    void Awake()
    {
        lastPos = transform.position;
        distance = 0;
    }
    // Count up distance travelled
    void Update()
    {
        Vector3 newPos = transform.position;
        distance += Vector3.Magnitude(newPos - lastPos);
        lastPos = newPos;
        // If we are out of range, destroy
        if(distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
    // Detect collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.gameObject.GetComponent<Character>();
        // If null we hit a wall or a non-character, therefore destroy the bullet
        if(!c)
        {
            Debug.Log(collision.gameObject.layer);
            Destroy(gameObject);
        } else
        {
            // If valid character and the groups differ, count as a hit
            if(c.gameObject.layer != layer)
            {
                c.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
