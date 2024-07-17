using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab of the projectile to shoot
    public Transform shootPoint;         // Point from where the projectile is shot

    void Update()
    {
        // Rotate the object towards the mouse pointer
        RotateTowardsMouse();

        // Shoot projectile on mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            ShootProjectile();
        }
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
    }
}