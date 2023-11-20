using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    [SerializeField] private int monsterAttack;

    [SerializeField] private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHP.Instance.PlayerTakeDamage(monsterAttack);
        }
    }
    [SerializeField] private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHP.Instance.PlayerTakeDamage(monsterAttack);
        }
    }
}
