using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Score")]
    public int _currentScore;

    public void ScoreAdder(int score)
    {
        _currentScore = _currentScore + score;
    }
}
