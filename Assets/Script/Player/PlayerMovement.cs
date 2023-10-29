using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;

    public float defaultMovementSpeed;
    
    public Rigidbody2D rg2d;


    private float countdownDash = 0;
    private float cooldown = 0.2f;
    
    
    
    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        countdownDash += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 20;
            countdownDash = 0;
        }

        if (countdownDash > cooldown)
        {
            movementSpeed = defaultMovementSpeed;
        }
      
        
        rg2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal")
            ,Input.GetAxisRaw("Vertical")) * movementSpeed;
    }
}
