using UnityEngine;

public class MonsterApple : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private Animator anim;
    [SerializeField] private bool playerDetect;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerDetectRange;
    [SerializeField] private LayerMask playerLayerMask;

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        UpdateMovement();
        UpdatePlayerDetection();
    }

    private void InitializeVariables()
    {
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponentInChildren<Animator>();
    }

    private void UpdateMovement()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }

    private void UpdatePlayerDetection()
    {
        playerDetect = Physics2D.OverlapCircle(transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect)
        {
            anim.SetBool("Idle", true);
        }
        else
        {
            anim.SetBool("Idle", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = playerDetect ? Color.red : Color.white;
        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}
