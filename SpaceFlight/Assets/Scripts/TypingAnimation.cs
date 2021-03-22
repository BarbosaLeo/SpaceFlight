using TMPro;
using System.Collections;
using UnityEngine;

public class TypingAnimation : MonoBehaviour
{
    public TMP_Text txt;
    string story;

    [SerializeField] bool isEndPanel = false;

    private void Awake()
    {
        txt.ToString();
        story = txt.text;
        txt.text = "";
    }

    void Start()
    {
        StartCoroutine("PlayText");
    }

    public void StartText()
    {
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine("DestroyText");

    }

    IEnumerator DestroyText()
    {

        for (float i = txt.color.a; i >= 0; i-=.01f)
        {
            Color c = txt.color;
            c.a = i;
            txt.color = c;
            yield return new WaitForSeconds(.05f);
        }

        this.gameObject.SetActive(false);
        
        if (isEndPanel)
        {
            GameState._gameOver = true;
        }

        Destroy(txt.gameObject);

    }
}
