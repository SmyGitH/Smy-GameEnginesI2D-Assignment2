using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text levelText;
    public Text timerText;
    public float score;
    public float level;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        level = 1f;
        timer = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        levelText.text = "Level: " + level;
        timerText.text = "Level Time: " + timer;
       
    }
}