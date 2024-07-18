using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BulletSpawner : ScriptableObject
{
    private IFirearm f;
    private GameObject bulletPrefab;

    public void Initialize(IFirearm f)
    {
        this.f = f;
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }
    public GameObject spawn(Vector3 location)
    {
        Vector3 velocity = f.BulletSpeed*(f.transform.rotation * Vector3.right);

        GameObject g = Instantiate(bulletPrefab, location, f.transform.rotation);
        Bullet b = g.GetComponent<Bullet>();
        // Set the range in the bullet before we set its velocity (motion)
        b.Initialize(f.Range,f.Layer,f.Damage);
        // Set the layer this gun was fired in (player layer, enemy layer)
        g.GetComponent<Rigidbody2D>().velocity = velocity;
        return g;
    }
}