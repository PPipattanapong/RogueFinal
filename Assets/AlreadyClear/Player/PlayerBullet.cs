using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Vector3 worldMousePosition;
    [SerializeField] private Vector3 direction;

    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float bulletSpeed = 5f;

    [SerializeField] private int bulletAttack = 5;
    void Start()
    {
        worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rg2d = GetComponent<Rigidbody2D>();
        direction = worldMousePosition - transform.position;

        direction.Normalize();

        rg2d.velocity = direction * bulletSpeed;
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Enemy"))
        {
            MonsterHP monsterHP = other.GetComponent<MonsterHP>();
            monsterHP.MonsterTakeDamage(bulletAttack);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
