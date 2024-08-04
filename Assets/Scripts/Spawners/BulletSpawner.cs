using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private IFirearm f;
    private GameObject bulletPrefab;

    public void Initialize(IFirearm f)
    {
        this.f = f;
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }
    public override GameObject spawn(Vector3 location)
    {
        // Get velocity vector
        Vector3 velocity = f.BulletSpeed*(f.transform.rotation * Vector3.right);
        // Rotate velocity vector via bullet spread angle
        float rotZ = Random.Range(-f.BulletSpread/2, f.BulletSpread/2);
        Quaternion rot = Quaternion.Euler(0,0,rotZ);
        velocity = rot * velocity;
        // Instantiate bullet
        GameObject g = Instantiate(bulletPrefab, location, f.transform.rotation);
        Bullet b = g.GetComponent<Bullet>();
        // Set the range in the bullet before we set its velocity (motion)
        b.Initialize(f.Range,f.gameObject.layer,f.Damage);
        // Make the bullet move
        g.GetComponent<Rigidbody2D>().velocity = velocity;
        return g;
    }
}