using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOrange : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator anim;
    [SerializeField] private bool playerDetect;
    [SerializeField] private float playerDetectRange;
    [SerializeField] private LayerMask playerLayerMask;

    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateSet;
    void Start()
    {
        fireRate = fireRateSet;
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        Vector3 direction = (player.transform.position
    - transform.position).normalized;

        #region[1] DetectPlayer

        playerDetect = Physics2D.OverlapCircle
    (transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect == true)
        {
            anim.SetBool("Idle", true);
            rg2d.velocity = Vector2.zero;

            if (fireRate <= 0)
            {
                Instantiate(prefabBullet, transform.position, Quaternion.identity);

                fireRate = fireRateSet;
            }

        }
        else
        {
            anim.SetBool("Idle", false);
            rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
        }
        #endregion
    }
    void OnDrawGizmos()
    {
        if (playerDetect) { Gizmos.color = Color.red; }
        else { Gizmos.color = Color.white; }

        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}