using System.Collections;
using UnityEngine;

public class AimAttack : MonoBehaviour
{
    public GameObject aim;
    public GameObject bullet;
    public GameObject firepoint;
    public float reloadTime = 2f;
    public int shotsBeforeReload = 10;

    private int shotCount = 0;
    private bool isReloading = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        float angle = Mathf.Atan2((mousePos.y - screenPoint.y), (mousePos.x - screenPoint.x)) * Mathf.Rad2Deg;

        aim.transform.rotation = Quaternion.Euler(0, 0, angle);

        /*if (mousePos.x >= screenPoint.x)
        {
            aim.SetActive(true); // Show the aim when on the right side
        }
        else
        {
            aim.SetActive(false); // Hide the aim when on the left side
        }*/

        if (Input.GetMouseButtonDown(0) && !isReloading /*&& mousePos.x >= screenPoint.x*/)
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
