using UnityEngine;

public class EndGameSequence : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject beginPanel;

    private void Start()
    {
        beginPanel.SetActive(true);
    }

    void Update()
    {
        if (GameState._gameEnded)
        {
            endPanel.SetActive(true);
        }
    }
}
