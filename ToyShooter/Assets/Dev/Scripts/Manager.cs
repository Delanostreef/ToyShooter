using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [Header("Enemies Before Boss Spawns")]
    public int bossCountDown;
    private TextMeshProUGUI bossSpawn;
    

    void Start()
    {
        bossSpawn = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bossSpawn.text = ("Boss In: " + bossCountDown);
    }
}
