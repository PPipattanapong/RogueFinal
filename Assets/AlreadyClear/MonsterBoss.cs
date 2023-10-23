using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator anim;
    [SerializeField] private bool playerDetect;
    [SerializeField] private float playerDetectRange;
    [SerializeField] private LayerMask playerLayerMask;

    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateSet;

    [SerializeField] private float punchSpeed;

    [SerializeField] private Vector2 punchDirection;

    [SerializeField] private int punchTime = 1;

    void Start()
    {
        punchSpeed = 20;
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

        punchDirection = direction;

        #region[1] DetectPlayer

        playerDetect = Physics2D.OverlapCircle
    (transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect == true)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", true);

            if (fireRate <= 0)
            {
                StartCoroutine(PunchTime());
                fireRate = fireRateSet;
            }
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Attack", false);
            rg2d.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
        }
        #endregion
    }
    IEnumerator PunchTime()
    {
        rg2d.velocity = Vector2.zero;
       yield return new WaitForSeconds(1f);
        rg2d.velocity = punchDirection * punchSpeed * punchTime;
        punchTime++;
        if (punchTime >= 3) punchTime = 1;
    }
    void OnDrawGizmos()
    {
        if (playerDetect) { Gizmos.color = Color.red; }
        else { Gizmos.color = Color.white; }

        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}
