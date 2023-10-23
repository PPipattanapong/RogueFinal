using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power2 : MonoBehaviour
{
    [SerializeField] private int bulletAttack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
}
