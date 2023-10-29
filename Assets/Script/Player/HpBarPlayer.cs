using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarPlayer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBarPlayer(float currentp1Value, float maxp1Value)
    {
        slider.value = currentp1Value / maxp1Value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}