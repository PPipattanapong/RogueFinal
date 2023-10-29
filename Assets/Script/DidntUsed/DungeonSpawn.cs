using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawn : MonoBehaviour
{
    [SerializeField] private float timeTracker;

    [SerializeField] private GameObject applePre;
    [SerializeField] private float spawntimeMon1;

    [SerializeField] private GameObject orangePre;
    [SerializeField] private float spawntimeMon2;

    [SerializeField] private GameObject bossPre;
    [SerializeField] private float spawntimeMon3;

    [SerializeField] private Transform spawnLeft;
    [SerializeField] private Transform spawnRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTracker += Time.deltaTime;
        spawntimeMon1 -= Time.deltaTime;
        spawntimeMon2 -= Time.deltaTime;
        spawntimeMon3 -= Time.deltaTime;

        if (timeTracker <= 30f)
        {
            if (spawntimeMon1 <= 0)
            {
                Instantiate(applePre, spawnLeft.position, Quaternion.identity);
                spawntimeMon1 = 2f;
            }
        }

        if (timeTracker >= 30f && timeTracker <= 60f)
        {
            if (spawntimeMon1 <= 0)
            {
                Instantiate(applePre, spawnLeft.position, Quaternion.identity);
                spawntimeMon1 = 2f;
            }
            if (spawntimeMon2 <= 0)
            {
                Instantiate(orangePre, spawnRight.position, Quaternion.identity);
                spawntimeMon2 = 2f;
            }
        }

        if (timeTracker >= 60)
        {
            if (spawntimeMon1 <= 0)
            {
                Instantiate(applePre, spawnLeft.position, Quaternion.identity);
                spawntimeMon1 = 2f;
            }
            if (spawntimeMon2 <= 0)
            {
                Instantiate(orangePre, spawnRight.position, Quaternion.identity);
                spawntimeMon2 = 2f;

            }
            if (spawntimeMon3 <= 0)
            {
                Instantiate(bossPre, spawnRight.position, Quaternion.identity);
                spawntimeMon3 = 10f;

            }
        }
    }
}
