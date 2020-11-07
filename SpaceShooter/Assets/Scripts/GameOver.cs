using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text gameOver;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score " + gameManager.score;

        if(gameManager.gameWon == true){
            gameOver.text = "You Won";
        }

        if (gameManager.gameLost == true){
            gameOver.text = "You Lost";
        }
    }

    public void RestartGame(){
         SceneManager.LoadScene("GameScene");
         gameManager.gameWon = false;
         gameManager.gameLost = false;
         gameManager.gameHasEnded = false;
         gameManager.score = 0f;
         gameManager.level = 0f;
         gameManager.timer = 0f;
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }

}
