using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Player player;

    private void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        text.text = player.GetScore().ToString();
    }
}
