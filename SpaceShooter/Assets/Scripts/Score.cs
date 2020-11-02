using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text levelText;
    public Text timerText;
    public Text healthText;
    
    private GameManager gm;
    private CollisionHandler ch;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ch = GameObject.Find("PlayerShip").GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gm.score;
        levelText.text = "Level: " + gm.level;
        timerText.text = "Level Time: " + (int)gm.timer;
        healthText.text = "Health: " + ch.health;
    }
}