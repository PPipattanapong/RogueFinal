using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHP hp = other.gameObject.GetComponent<PlayerHP>();
            hp.increaseHp();
        }
    }
}
