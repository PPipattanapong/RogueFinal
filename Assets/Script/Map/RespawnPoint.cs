using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerHP hp = col.gameObject.GetComponent<PlayerHP>();
            hp.respawnPoint = transform.position;
        }
        
    }
}
