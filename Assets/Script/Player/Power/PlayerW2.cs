using UnityEngine;

public class PlayerW2 : MonoBehaviour
{
    [SerializeField] private GameObject energy;
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private float cooldownSet = 7f;
    [SerializeField] private float lifetime = 3.5f;

    private float cooldown;

    private void Update()
    {
        RotateEnergy();
        UpdateCooldown();
    }

    private void RotateEnergy()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotationSpeed * Time.deltaTime));
    }

    private void UpdateCooldown()
    {
        cooldown -= Time.deltaTime;
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            SetEnergyActive(false);
        }

        if (cooldown <= 0)
        {
            SetEnergyActive(true);
            ResetCooldown();
        }
    }

    private void SetEnergyActive(bool isActive)
    {
        energy.SetActive(isActive);
    }

    private void ResetCooldown()
    {
        cooldown = cooldownSet;
        lifetime = 3.5f;
    }
}
