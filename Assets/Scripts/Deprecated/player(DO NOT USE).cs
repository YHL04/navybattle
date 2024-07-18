using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
