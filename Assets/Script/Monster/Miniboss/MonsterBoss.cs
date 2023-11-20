using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject spawnPrefab2;

    private int punchCounter = 0;

    private void Start()
    {
        punchSpeed = 20;
        fireRate = fireRateSet;
        rg2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponentInChildren <Animator>();
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;

        Vector3 direction = (player.transform.position - transform.position).normalized;

        punchDirection = direction;

        DetectPlayer(direction);
    }

    private void DetectPlayer(Vector3 direction)
    {
        playerDetect = Physics2D.OverlapCircle(transform.position, playerDetectRange, playerLayerMask);

        if (playerDetect)
        {
            anim.SetBool("Attack", true);

            if (fireRate <= 0)
            {
                StartCoroutine(PunchTime());
                fireRate = fireRateSet;
            }
        }
        else
        {
            anim.SetBool("Attack", false);
            rg2d.velocity = direction * moveSpeed;
        }
    }

    private IEnumerator PunchTime()
    {
        rg2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        rg2d.velocity = punchDirection * punchSpeed * punchTime;
        punchTime++;

        if (punchTime >= 2)
        {
            punchCounter++;
            if (SceneManager.GetActiveScene().name == "Level3" && punchCounter >= 3)
            {
                SpawnGameObject();
                if (punchCounter >= 5)
                {
                    SpawnGameObject2();
                    punchCounter = 0;
                    punchTime = 1;
                }
            }
        }
    }

    private void SpawnGameObject()
    {
        if (spawnPrefab != null)
        {
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Spawn prefab is not assigned in the inspector!");
        }
    }

    private void SpawnGameObject2()
    {
        if (spawnPrefab2 != null)
        {
            Instantiate(spawnPrefab2, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Spawn prefab2 is not assigned in the inspector!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = playerDetect ? Color.red : Color.white;
        Gizmos.DrawWireSphere(transform.position, playerDetectRange);
    }
}
