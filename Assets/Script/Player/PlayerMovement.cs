using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float defaultMovementSpeed;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float dashCooldown = 1.0f; 

    private float countdownDash = 0f;
    private bool isDashing = false;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateDashTimers();
        UpdateDashState();
        HandleMovementInput();
    }

    private void Initialize()
    {
        defaultMovementSpeed = movementSpeed;
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void UpdateDashTimers()
    {
        countdownDash += Time.deltaTime;
        dashCooldown = Mathf.Clamp(dashCooldown + Time.deltaTime, 0f, 1.0f);
    }

    private void UpdateDashState()
    {
        if (isDashing)
        {
            countdownDash -= Time.deltaTime;

            if (countdownDash <= 0)
            {
                isDashing = false;
                countdownDash = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown >= 1.0f)
            {
                ActivateDash();
            }

            if (countdownDash > 0.2f)
            {
                ResetMovementSpeed();
            }
        }
    }

    private void HandleMovementInput()
    {
        rg2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movementSpeed;
    }

    private void ActivateDash()
    {
        isDashing = true;
        countdownDash = 0;
        movementSpeed = 20; 
        dashCooldown = 0;  
    }

    private void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }
}
