using System.Collections;
using UnityEngine;

public class AimAttack : MonoBehaviour
{
    public GameObject aim;
    public GameObject bullet;
    public GameObject firepoint;
    public float reloadTime = 2f; // Adjust the reload time as needed
    public int shotsBeforeReload = 10; // Number of shots before reloading

    private int shotCount = 0;
    private bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        float angle = Mathf.Atan2((mousePos.y - screenPoint.y), (mousePos.x - screenPoint.x)) * Mathf.Rad2Deg;

        aim.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            Instantiate(bullet, firepoint.transform.position, aim.transform.rotation);
            shotCount++;

            if (shotCount >= shotsBeforeReload)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        shotCount = 0; // Reset the shot count
    }
}