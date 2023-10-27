using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;

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
        if (currentHp <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("1 point earn");

            Player player = GameObject.FindFirstObjectByType<Player>();
            player.AddScore();

            gameObject.SetActive(false);
        }
    }
}
