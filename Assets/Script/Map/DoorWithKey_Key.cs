using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey_Key : MonoBehaviour
{
    public GameObject door1;
    // Start is called before the first frame update
    void Start()
    {
      //  door1 = GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            DoorWithKey_Door door = door1.GetComponent<DoorWithKey_Door>();
            door.havekey = true;
            
            Destroy(gameObject);

        }
    }
}
