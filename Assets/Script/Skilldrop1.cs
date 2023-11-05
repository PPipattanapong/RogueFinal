using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skilldrop1 : MonoBehaviour
{
    [SerializeField] private GameObject Skillshield;
    [SerializeField] private GameObject Itemskill;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Skillshield.SetActive(true);
            Destroy(gameObject);
        }
    }

}