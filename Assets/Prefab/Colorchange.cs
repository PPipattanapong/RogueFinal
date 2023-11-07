using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Colorchange : MonoBehaviour
{
    [SerializeField] private int blinking = 5;

    [SerializeField] private float delay = 0.3f;


    public Color oldColor;
    public int count = 0;

     /*void Start()
    {
        StartCoroutine(play());

    }*/

    public void PlayEffect()
    {
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        Renderer renderer= GetComponent<Renderer>();

        oldColor = renderer.material.color;

        while (count < blinking)
        {
            renderer.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(delay);
            renderer.material.SetColor("_Color", oldColor);
            yield return new WaitForSeconds(delay);
            renderer.material.SetColor("_Color", Color.red);

            yield return null;

            count++;
        }
    }
}