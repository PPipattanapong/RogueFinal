using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public static PlayerHP Instance;
    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;

    [SerializeField] private Transform hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.localScale = new Vector3(currentHp / maxHp, hpBar.localScale.y,
            hpBar.localScale.z);
    }
    public void PlayerTakeDamage(int damageFromMonster)
    {
        currentHp -= damageFromMonster;
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
