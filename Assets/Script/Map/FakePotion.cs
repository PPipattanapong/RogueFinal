using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHP downhp = col.gameObject.GetComponent<PlayerHP>();

            downhp.deHp();

            Destroy(gameObject);
        }
    }

}