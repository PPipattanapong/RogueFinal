using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        InitializeBulletMovement();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void InitializeBulletMovement()
    {
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        Vector3 direction = (player.transform.position - transform.position).normalized;
        rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }
}
