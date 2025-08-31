using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{
    public bool isWinnerScene;
    public TextMeshProUGUI textcomponent;

    float timer = 0f;
    bool canGoback = false;

    private void Start()
    {
        if (isWinnerScene)
        {
            ShowScore();
        }
        else
        {
            SoundManager.PlaySound(SoundType.MUSICADERROTA);
        }
    }

    private void ShowScore()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        int _minutes = score / 60;
        int _seconds = score % 60;
        textcomponent.text = "Score => " + _minutes.ToString("00") + ":" + _seconds.ToString("00");

        int Hscore = PlayerPrefs.GetInt("Highscore", 0);
        int _Hminutes = Hscore / 60;
        int _Hseconds = Hscore % 60;
        textcomponent.text = "Score: " + _Hminutes.ToString("00") + ":" + _Hseconds.ToString("00");
    }

    public void BackToMainMenu()
    {
        if (canGoback)
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            canGoback = true;
        }
    }
}
