using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletAttack = 5;

    private void Start()
    {
        InitializeComponents();
    }

    private void Update()
    {
        MoveBullet();
    }

    private void InitializeComponents()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void MoveBullet()
    {
        rg2d.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MonsterHP monsterHP = other.GetComponent<MonsterHP>();
            monsterHP?.MonsterTakeDamage(bulletAttack);
        }
    }

    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
