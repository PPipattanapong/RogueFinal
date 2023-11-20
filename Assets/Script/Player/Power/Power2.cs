using UnityEngine;

public class Power2 : MonoBehaviour
{
    [SerializeField] private int bulletAttack;

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
}
