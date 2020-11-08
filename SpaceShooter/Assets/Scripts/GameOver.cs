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
    private CollisionHandler collisionHandler;
    // Start is called before the first frame update

    private void Awake() 
    {
        
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        collisionHandler = GameObject.Find("PlayerShip").GetComponent<CollisionHandler>();
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
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }

}
