using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int _score;
    public int _scoreAmount;
 
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ScoreAdder(int score)
    {
        score = _score;
    }
}
