using TMPro;
using UnityEngine;

public class GameProgressUI : MonoBehaviour
{
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text matchesText;
    [SerializeField] private TMP_Text turnsText;
    [SerializeField] private TMP_Text gameOverText;


    public void UpdateTurns(int turns)
    {
        if (turnsText != null)
            turnsText.text = turns.ToString();
    }

    public void UpdateMatches(int matches)
    {
        if (matchesText != null)
            matchesText.text = matches.ToString();
    }
    
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void UpdateHighscore(int highscore)
    {
        if (highscoreText != null)
            highscoreText.text = highscore.ToString();
    }

    public void ShowGameOver(bool isNewRecord)
    {
        if (gameOverText == null) return;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = isNewRecord ? "New Record!" : "Game Over";
    }

    public void HideGameOver()
    {
        if (gameOverText == null) return;
        gameOverText.gameObject.SetActive(false);
    }
}
