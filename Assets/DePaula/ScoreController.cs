using UnityEngine;

public static class ScoreController
{
    public static void SetScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.GetInt("Highscore", 0) < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
