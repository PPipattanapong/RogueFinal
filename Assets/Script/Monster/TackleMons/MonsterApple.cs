using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterApple : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator anim;
    [SerializeField] private bool playerDetect;
    [SerializeField] private float playerDetectRange;
    [SerializeField] private LayerMask playerLayerMask;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position
            - transform.position).normalized;

        rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

        playerDetect = Physics2D.OverlapCircle
            (transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect == true)
        { 
                anim.SetBool("Idle", true);
    }
        else
        {
            anim.SetBool("Idle", false);
        }
    }
    void OnDrawGizmos()
    {
        if (playerDetect) { Gizmos.color = Color.red; }
        else { Gizmos.color = Color.white; }
        
        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}
