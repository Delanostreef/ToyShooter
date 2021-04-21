using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Score")]
    public int currentScore;

    public int lastHighscore;

    private void Update()
    {
        
    }

    public void ScoreAdder(int score)
    {
        currentScore = currentScore + score;
    }
}
