using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Melee : MonoBehaviour
{
    [SerializeField] private GameObject Energy;

    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownSet = 7f;

    [SerializeField] private float lifetime = 3.5f;



    private void Start()
    {
    }

    private void Update()
    {

        cooldown -= Time.deltaTime;
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Energy.SetActive(false);
        }

        if (cooldown <= 0)
        {
            Energy.SetActive(true);
            cooldown = cooldownSet;
            lifetime = 3.5f;
        }
    }
}