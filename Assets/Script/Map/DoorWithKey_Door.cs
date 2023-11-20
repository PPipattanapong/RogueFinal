using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey_Door : MonoBehaviour
{
    public bool havekey = false; 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (havekey == true && col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
