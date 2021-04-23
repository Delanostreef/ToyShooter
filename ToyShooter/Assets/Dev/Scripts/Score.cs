using UnityEngine.SceneManagement;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _currentScore;
    private int _highscore;
    private int _lastHighscore;

    [SerializeField] private TMPro.TMP_Text _lastHighscoreText;
    [SerializeField] private TMPro.TMP_Text _currentScoreText;
    [SerializeField] private TMPro.TMP_Text _highscoreText;

    private void Update()
    {
        _currentScoreText.text = "Score: " + _currentScore.ToString("000000");
        _highscoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        _lastHighscoreText.text = PlayerPrefs.GetInt("lastHighscore").ToString();

        if (SceneManager.GetActiveScene().buildIndex == 1 && _currentScore >= PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", _currentScore);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1 && _currentScore < PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("lastHighscore", _currentScore);
        }

        //print(_currentScore);
        //print(PlayerPrefs.GetInt("lastHighscore", 0));  

        //if (_currentScore >= PlayerPrefs.GetInt("highscore", 0))
        //{
        //    PlayerPrefs.SetInt("highscore", _currentScore);
        //    PlayerPrefs.SetInt("lastHighscore", _currentScore);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("lastHighscore", _currentScore);
        //}


    }

    public void ScoreAdder(int score)
    {
        _currentScore = _currentScore + score;
    }
}
