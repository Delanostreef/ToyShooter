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
       // _highscoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
      //  _lastHighscoreText.text = PlayerPrefs.GetInt("lastHighscore", 0).ToString();

        if (_currentScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", _currentScore);
            _highscore = _currentScore;
        }

        if (_highscore > PlayerPrefs.GetInt("lastHighscore", 0))
        {
            PlayerPrefs.SetInt("lastHighscore", PlayerPrefs.GetInt("highscore", _highscore));
            _lastHighscore = _highscore;
        }

        print(PlayerPrefs.GetInt("lastHighscore", 0));

    }

    public void ScoreAdder(int score)
    {
        _currentScore = _currentScore + score;
    }
}
