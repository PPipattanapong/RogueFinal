using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;
    [SerializeField] FloatingHealthBar healthBar;

    public GameObject itemdrop;

    public int droprateItem1 = 25;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MonsterTakeDamage(int damageFromPlayer)
    {
        currentHp -= damageFromPlayer;
        healthBar.UpdateHealthBar(currentHp, maxHp);
        if (currentHp <= 0)
        {
            if (Random.Range(0, 100) < droprateItem1)
            {
                Instantiate(itemdrop, transform.position, transform.rotation);
            }

            //Destroy(gameObject);
            Debug.Log("1 KILL");

            Player player = GameObject.FindFirstObjectByType<Player>();
            player.AddScore();

            gameObject.SetActive(false);
        }
    }
}
