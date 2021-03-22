using UnityEngine;

public class PauseGameMenu : MonoBehaviour
{
    public GameObject hudUI;
    public GameObject beginPanel;
    public GameObject pauseMenuUI;

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (GameState._gamePaused)
            Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState._gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        hudUI.SetActive(true);
        GameState._gamePaused = false;
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
        hudUI.SetActive(false);
        GameState._gamePaused = true;
        Time.timeScale = 0;
    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
