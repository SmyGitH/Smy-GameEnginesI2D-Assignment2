using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    private bool levelSetup = false;
    public Score scoreScript;
   
    public float gameTime;

    private void Awake() {
        scoreScript = gameObject.GetComponent<Score>();
    }

    void Start()
    {
        
        gameTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreScript.timer -= gameTime;

         if(scoreScript.timer <= 0){
            scoreScript.level++;
            levelSetup = false;
        }

        if(scoreScript.level == 1 && !levelSetup){
            scoreScript.timer = 120f;
            levelSetup = true;
        }else if(scoreScript.level == 2){
            scoreScript.timer = 140f;
            levelSetup = true;
        }else if(scoreScript.level == 3){
            scoreScript.timer = 160f;
            levelSetup = true;
        }
    }

    private void setLevel(){
       
    }
}
