using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool _gamePaused = false;
    public static bool _gameEnded = false;
    public static bool _gameOver = false;

    private void Update()
    {
        if (!_gamePaused)
        {
            Cursor.visible = false;
        }

        if (_gameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
        }
    }
}
