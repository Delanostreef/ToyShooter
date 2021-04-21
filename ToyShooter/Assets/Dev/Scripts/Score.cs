using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Score")]
    public int currentScore;

    public int highscore;
    public int lastHighscore;

    [SerializeField] private TMPro.TMP_Text _lastHighscoreText;
    [SerializeField] private TMPro.TMP_Text _currentScoreText;
    [SerializeField] private TMPro.TMP_Text _highscoreText;

    private void Update()
    {
        _currentScoreText.text = "score: " + currentScore;
        _highscoreText.text = "highscore: " + PlayerPrefs.GetInt("highscore", 0);
        _lastHighscoreText.text = "last highscore: " + PlayerPrefs.GetInt("lastHighscore", 0);

        if (currentScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            highscore = currentScore;
        }

        if (highscore > PlayerPrefs.GetInt("lastHighscore", 0))
        {
            PlayerPrefs.SetInt("lastHighscore", PlayerPrefs.GetInt("highscore", highscore));
            lastHighscore = highscore;
        }

        print(PlayerPrefs.GetInt("lastHighscore", 0));

    }

    public void ScoreAdder(int score)
    {
        currentScore = currentScore + score;
    }
}
