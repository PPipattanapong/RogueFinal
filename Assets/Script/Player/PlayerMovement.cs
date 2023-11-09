using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float defaultMovementSpeed;
    public Rigidbody2D rg2d;

    public float countdownDash = 0;
    public float dashCooldown = 2.0f; // Cooldown after dash (2 seconds)
    public bool isDashing = false;

    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        countdownDash += Time.deltaTime;

        if (isDashing)
        {
            // Dash is active, reduce dash duration
            countdownDash -= Time.deltaTime;

            if (countdownDash <= 0)
            {
                // Dash duration is over, disable dash
                isDashing = false;
                countdownDash = 0;
            }
        }
        else
        {
            // Dash is not active, check for input to activate dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown >= 2.0f)
            {
                isDashing = true;
                countdownDash = 0;
                movementSpeed = 20; // Set the dash speed
                dashCooldown = 0;  // Reset the cooldown timer
            }

            if (countdownDash > 0.2f)
            {
                movementSpeed = defaultMovementSpeed;
            }

            // Increase the cooldown timer even if not dashing
            if (dashCooldown < 2.0f)
            {
                dashCooldown += Time.deltaTime;
            }
        }

        rg2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movementSpeed;
    }
}