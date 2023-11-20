using UnityEngine;

public class MonsterOrange : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private Animator anim;
    [SerializeField] private bool playerDetect;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerDetectRange;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateSet;

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        UpdatePlayerDetection();
    }

    private void InitializeVariables()
    {
        fireRate = fireRateSet;
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponentInChildren<Animator>();
    }

    private void UpdatePlayerDetection()
    {
        fireRate -= Time.deltaTime;

        Vector3 direction = (player.transform.position - transform.position).normalized;

        playerDetect = Physics2D.OverlapCircle(transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect)
        {
            HandlePlayerDetection();
        }
        else
        {
            HandleNoPlayerDetection(direction);
        }
    }

    private void HandlePlayerDetection()
    {
        anim.SetBool("Idle", true);
        rg2d.velocity = Vector2.zero;

        if (fireRate <= 0)
        {
            Instantiate(prefabBullet, transform.position, Quaternion.identity);
            fireRate = fireRateSet;
        }
    }

    private void HandleNoPlayerDetection(Vector3 direction)
    {
        anim.SetBool("Idle", false);
        rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = playerDetect ? Color.red : Color.white;
        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}
