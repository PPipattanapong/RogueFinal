using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private GameObject energy;
    [SerializeField] private float cooldownSet = 7f;
    [SerializeField] private float lifetime = 3.5f;

    private float cooldown;

    private void Update()
    {
        UpdateCooldown();
        UpdateLifetime();
    }

    private void UpdateCooldown()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            ResetCooldown();
            ActivateEnergy();
        }
    }

    private void UpdateLifetime()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            energy.SetActive(false);
        }
    }

    private void ResetCooldown()
    {
        cooldown = cooldownSet;
    }

    private void ActivateEnergy()
    {
        energy.SetActive(true);
    }
}
