using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    public bool gamePaused;

    void Start()
    {
        Time.timeScale = 1F;
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            if(gamePaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }  
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0F;
        gamePaused = true;
    }
    
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1F;
        gamePaused = false;
    }    

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game");
        
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
