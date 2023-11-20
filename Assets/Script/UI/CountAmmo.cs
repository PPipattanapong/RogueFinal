using System.Collections;
using UnityEngine;
using TMPro;

public class CountAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float reloadTime = 2f;

    private int count = 10;
    private bool isReloading = false;

    private void Start()
    {
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        countdownText.text = count.ToString();
    }

    private void Update()
    {
        HandleShootingInput();
    }

    private void HandleShootingInput()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            if (count > 0)
            {
                Shoot();
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void Shoot()
    {
        count--;
        UpdateCountdownText();
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        ResetAmmo();
    }

    private void ResetAmmo()
    {
        count = 10;
        UpdateCountdownText();
    }
}
