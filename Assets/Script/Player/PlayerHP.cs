using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Vector3 respawnPoint;

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
        respawnPoint = Vector3.zero;
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
            //gameObject.SetActive(false);
            //transform.position = respawnPoint;
            //currentHp = maxHp;
            SceneManager.LoadScene(6);
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