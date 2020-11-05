using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    
   
    public float gameTime;
    public float score;
    public float level;
    public float timer;
    private float flashTimer;
    private float damageFlashTimer = 2f;
    private Animator levelFlash;
    private Text levelText;
    private Animator damageFlash;

    void Start()
    {
        
        levelFlash = GameObject.Find("Flash").GetComponent<Animator>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        damageFlash = GameObject.Find("DamageF").GetComponent<Animator>();
        gameTime = Time.deltaTime;
        score = 0f;
        level = 0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= gameTime / 5;

         if(timer <= 0){
           setLevel();
           levelFlash.SetBool("LevelSwitch", true);
           flashTimer = 3f;
        }

        if(flashTimer > 0){
            flashTimer -= gameTime / 2;
            if(flashTimer <= 0){
                levelFlash.SetBool("LevelSwitch", false);
            }
        }

        if(damageFlash.GetBool("Damaged") == true){
            damageFlashTimer -= gameTime;

            if(damageFlashTimer <= 0){
                damageFlash.SetBool("Damaged", false);
                damageFlashTimer = 2f;
            }
        }
    
        levelText.text = "Level " + level;
        
    }

    private void setLevel(){

        level++;


        switch(level){
            case 1: timer = 10f;
            DestroyBosses();
            DestroyEnemies();
            break;

            case 2: timer = 140f;
            DestroyBosses();
            DestroyEnemies();
            
            break;

            case 3: timer = 160f;
            DestroyBosses();
            DestroyEnemies();
            break;

            default:
            break;       
        }
    }

    private void DestroyEnemies(){
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++){
            GameObject.Destroy(enemies[i]);
        }
    }

    private void DestroyBosses(){

        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        for (int i = 0; i < bosses.Length; i++){
            GameObject.Destroy(bosses[i]);
        }
    }
}
