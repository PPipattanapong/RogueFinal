using System.Collections;
using UnityEngine;
using TMPro;

public class CountAmmo : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float reloadTime = 2f;

    private int count = 10;
    private bool isReloading = false;

    void Start()
    {
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        countdownText.text = count.ToString();
    }

    void Update()
    {
        // Check if the mouse position is on the right side of the screen
        if (Input.GetMouseButtonDown(0) && !isReloading && Input.mousePosition.x > Screen.width / 2)
        {
            if (count > 0)
            {
                count--;
                UpdateCountdownText();
            }
            else
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
        count = 10; // Reset the countdown
        UpdateCountdownText();
    }
}
