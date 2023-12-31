using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private GameObject Skill1
        ;
    [SerializeField] private GameObject Skill2;

    public Vector3 respawnPoint;

    public static PlayerHP Instance;
    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;

    [SerializeField] private Transform hpBar;

    void Start()
    {
        currentHp = maxHp;
        respawnPoint = Vector3.zero;
    }

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
            SceneManager.LoadScene(6);
            Skill1.SetActive(false);
            Skill2.SetActive(false);

        }
    }
    public void increaseHp()
    {

        if (currentHp < maxHp)
        {
            currentHp += 10;
        }

    }
    public void deHp()
    {

        if (currentHp <= maxHp)
        {
            currentHp -= 25;
        }

    }
}