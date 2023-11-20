using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private static bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void Resume()
    {
        SetPauseUIActive(false);
        SetTimeScale(1f);
        gamePaused = false;
    }

    public void Pause()
    {
        SetPauseUIActive(true);
        SetTimeScale(0f);
        gamePaused = true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void TogglePause()
    {
        if (gamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void SetPauseUIActive(bool isActive)
    {
        pauseUI.SetActive(isActive);
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}