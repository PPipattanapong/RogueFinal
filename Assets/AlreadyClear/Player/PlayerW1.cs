using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerW1 : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float cooldown;
    [SerializeField] private float firerate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(bulletPrefabs, transform.position, Quaternion.
                identity);
            cooldown = firerate;
        }
    }
}
