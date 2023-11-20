using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;
    [SerializeField] private FloatingHealthBar healthBar;
    [SerializeField] private GameObject itemdrop;
    [SerializeField] private GameObject itemdrop2;
    [SerializeField] private int droprateItem1 = 25;
    [SerializeField] private int droprateItem2 = 5;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        InitializeHealth();
    }

    private void Update()
    {
        // No update logic for now
    }

    public void MonsterTakeDamage(int damageFromPlayer)
    {
        currentHp -= damageFromPlayer;
        healthBar.UpdateHealthBar(currentHp, maxHp);

        if (currentHp <= 0)
        {
            HandleDeath();
        }
    }

    private void InitializeHealth()
    {
        currentHp = maxHp;
    }

    private void HandleDeath()
    {
        if (Random.Range(0, 100) < droprateItem1)
        {
            Instantiate(itemdrop, transform.position, transform.rotation);
        }
        if (Random.Range(0, 100) < droprateItem2)
        {
            Instantiate(itemdrop2, transform.position, transform.rotation);
        }

        //Destroy(gameObject);
        Debug.Log("1 KILL");

        Player player = GameObject.FindObjectOfType<Player>();
        player?.AddScore();

        gameObject.SetActive(false);
    }
}