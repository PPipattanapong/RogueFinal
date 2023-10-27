using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Player player;

    //PlayerController player;

    void Start()
    {
        //text = GetComponent<TMP_Text>();

        //player = GameObject.FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        text.text = player.GetScore().ToString();
    }
}
