using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject missionMenu;

    public void StartHistoryMode()
    {
    }

    public void StartTrainingMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level0");
    }

    public void OpenMissionMenu()
    {
        missionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        missionMenu.SetActive(false);
    }

    public void OptionsPopUp()
    {
        //options panel here
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
