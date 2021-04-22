using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [Header("Enemies Before Boss Spawns")]
    public int bossCountDown;

    [Header("Text")]
    private TextMeshProUGUI bossSpawn;
    private TextMeshProUGUI scoreCounter;

    void Start()
    {
        bossSpawn = FindObjectOfType<TextMeshProUGUI>();
        scoreCounter = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
      //  scoreCounter.text = ("Score: " + );
        bossSpawn.text = ("Boss In: " + bossCountDown);
    }
}
