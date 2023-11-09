using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Next Level");

            // Check if the current scene is "Scene1" before loading "Scene3"
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("WinScene");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}