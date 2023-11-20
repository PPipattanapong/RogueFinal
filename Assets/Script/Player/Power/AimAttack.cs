using System.Collections;
using UnityEngine;

public class AimAttack : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private int shotsBeforeReload = 10;

    private int shotCount = 0;
    private bool isReloading = false;

    private void Update()
    {
        HandleAimRotation();
        HandleShooting();
    }

    private void HandleAimRotation()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        float angle = Mathf.Atan2((mousePos.y - screenPoint.y), (mousePos.x - screenPoint.x)) * Mathf.Rad2Deg;

        aim.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        Instantiate(bullet, firepoint.transform.position, aim.transform.rotation);
        shotCount++;

        if (shotCount >= shotsBeforeReload)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        ResetShotCount();
    }

    private void ResetShotCount()
    {
        shotCount = 0;
    }
}