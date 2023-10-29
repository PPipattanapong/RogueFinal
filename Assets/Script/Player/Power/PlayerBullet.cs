using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float bulletSpeed = 5f;

    [SerializeField] private int bulletAttack = 5;
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rg2d.velocity = transform.right * bulletSpeed;
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
