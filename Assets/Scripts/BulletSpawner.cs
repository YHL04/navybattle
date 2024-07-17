using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ScriptableObject
{
    public void spawnBullet(GameObject prefab, Firearm gun, int layer)
    {
        Vector3 loc = gun.transform.position;
        Vector3 velocity = gun.BulletSpeed*(gun.transform.rotation * Vector3.right);

        GameObject g = Instantiate(prefab, loc, gun.transform.rotation);
        Bullet b = g.GetComponent<Bullet>();
        // Set the range in the bullet before we set its velocity (motion)
        b.Initialize(gun.Range,layer,gun.Damage);
        // Set the layer this gun was fired in (player layer, enemy layer)
        g.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}