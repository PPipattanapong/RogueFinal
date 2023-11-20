using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            PlayerHP hp = col.gameObject.GetComponent<PlayerHP>();
            
            hp.increaseHp();
            
            Destroy(gameObject);
            
        }
    }
    
}
