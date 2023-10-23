using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerW2 : MonoBehaviour
{
    [SerializeField] private GameObject Energy;
    [SerializeField] private float rotationspeed = 180f;

    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownSet = 7f;

    [SerializeField] private float lifetime = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, transform.
            rotation.eulerAngles.z + (rotationspeed*Time.deltaTime));

        cooldown -= Time.deltaTime;
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Energy.SetActive(false);
        }

        if (cooldown <= 0)
        {
            Energy.SetActive(true);
            cooldown = cooldownSet;
            lifetime = 3.5f;
        }
    }
}
