using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private Rigidbody2D rg2d;
    private Vector2 velocity;
    [SerializeField] private float moveSpeed;
    void Start()
    {
        rg2d = GetComponent <Rigidbody2D>();
    }
    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw
         ("Horizontal"), Input.GetAxisRaw("Vertical"));

        rg2d.velocity = velocity*moveSpeed;
    }
}

