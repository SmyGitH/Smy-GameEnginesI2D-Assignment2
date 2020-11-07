using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    
    public static GameManager Instance;
    public float gameTime;
    public float score;
    public float level;
    public float timer;
    private float flashTimer = 2f;
    private float damageFlashTimer = 2f;
    private float restartDelay = 2f;
    private bool gameHasEnded = false;
    private Animator levelFlash;
    private Text levelText;
    private Animator damageFlash;
    private GameObject BossSpawner2;
    private GameObject EnemySpawner2;
    private GameObject EnemySpawner3;
    private GameObject BossSpawner3;

     private void Awake() {
        SetInstance();
    }

    void SetInstance(){
        if(Instance == null){
            Instance = this;
        }else if (Instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
        levelFlash = GameObject.Find("Flash").GetComponent<Animator>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        damageFlash = GameObject.Find("DamageF").GetComponent<Animator>();
        BossSpawner2 = GameObject.Find("BossSpawner2");
        BossSpawner2.SetActive(false);
        BossSpawner3 = GameObject.Find("BossSpawner3");
        BossSpawner3.SetActive(false);
        EnemySpawner2 = GameObject.Find("EnemySpawner2");
        EnemySpawner2.SetActive(false);
        EnemySpawner3 = GameObject.Find("EnemySpawner3");
        EnemySpawner3.SetActive(false);
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
        }

       /* if(flashTimer > 0){
            flashTimer -= gameTime / 2;
            if(flashTimer <= 0){
                levelFlash.SetBool("LevelSwitch", false);
            }
        }*/

        if(levelFlash != null){ 

            if(levelFlash.GetBool("LevelSwitch") == true){
            flashTimer -= gameTime / 2;

            if(flashTimer <= 0){
                levelFlash.SetBool("LevelSwitch", false);
                flashTimer = 2f;
            }

        }else{
            levelFlash = GameObject.Find("Flash").GetComponent<Animator>();
        }

     }

        

        if(damageFlash != null){

             if(damageFlash.GetBool("Damaged") == true){
            damageFlashTimer -= gameTime;

            if(damageFlashTimer <= 0){
                damageFlash.SetBool("Damaged", false);
                damageFlashTimer = 2f;
                 }
            }
        }else{
            damageFlash = GameObject.Find("DamageF").GetComponent<Animator>();
        }

       
    
        levelText.text = "Level " + level;
        
    }

    private void setLevel(){

        level++;


        switch(level){
            case 1: timer = 25f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);
            break;

            case 2: timer = 35f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);

            BossSpawner2.SetActive(true);
            
            EnemySpawner2.SetActive(true);
            

            break;

            case 3: timer = 45f;
            DestroyBosses();
            DestroyEnemies();
             levelFlash.SetBool("LevelSwitch", true);
            
            BossSpawner3.SetActive(true);

            EnemySpawner3.SetActive(true);

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


    public void EndGame(){
        if(gameHasEnded == false){
            
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
        
    }

     public void Restart(){
        SceneManager.LoadScene("GameOver");
    }
}
