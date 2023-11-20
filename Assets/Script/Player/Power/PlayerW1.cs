using UnityEngine;

public class PlayerW1 : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private float fireRate = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            FireBullet();
            ResetCooldown();
        }
    }

    private void FireBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    private void ResetCooldown()
    {
        cooldown = fireRate;
    }
}
