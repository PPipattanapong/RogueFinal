using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skilldrop1 : MonoBehaviour
{
    [SerializeField] private GameObject Skillshield;
    [SerializeField] private GameObject Itemskill;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Skillshield.SetActive(true);
            Destroy(gameObject);
        }
    }

}