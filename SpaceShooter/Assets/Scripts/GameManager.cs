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
    //private float restartDelay = 2f;
    [HideInInspector] public bool gameHasEnded;
    [HideInInspector] public bool gameLost;
    [HideInInspector] public bool gameWon;
    private Animator levelFlash;
    private Text levelText;
    private Animator damageFlash;
    private GameObject BossSpawner1;
    private GameObject EnemySpawner1;
    private GameObject BossSpawner2;
    private GameObject EnemySpawner2;
    private GameObject EnemySpawner3;
    private GameObject BossSpawner3;
    private GameObject HUD;
    private GameObject gameOverHUD;

     private void Awake() {

        //SetInstance();
        
    }

    /*void SetInstance(){
        if(Instance == null){
            Instance = this;
        }else if (Instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }*/
    void Start()
    {
        gameTime = Time.deltaTime;
        BossSpawner1 = GameObject.Find("BossSpawner1");
        BossSpawner2 = GameObject.Find("BossSpawner2");
        BossSpawner3 = GameObject.Find("BossSpawner3");
        EnemySpawner1 = GameObject.Find("EnemySpawner1");
        EnemySpawner2 = GameObject.Find("EnemySpawner2");
        EnemySpawner3 = GameObject.Find("EnemySpawner3");
        gameHasEnded = false;
        gameWon = false;
        gameLost = false;
        HUD = GameObject.Find("HUD");
        gameOverHUD = GameObject.Find("GameOverHUD");
        levelFlash = GameObject.Find("Flash").GetComponent<Animator>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        damageFlash = GameObject.Find("DamageF").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(levelFlash != null){ 

            if(levelFlash.GetBool("LevelSwitch") == true){
            flashTimer -= gameTime / 2;

            if(flashTimer <= 0){
                levelFlash.SetBool("LevelSwitch", false);
                flashTimer = 2f;
            }

        }else if (levelFlash == null){
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


        timer -= gameTime / 5;

         if(timer <= 0){
           setLevel();
        }

        
         levelText.text = "Level " + level;
        
    }

    private void setLevel(){

        level++;

        if(gameHasEnded == false){
            switch(level){
            case 1: timer = 20f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);
            gameOverHUD.SetActive(false);
            BossSpawner2.SetActive(false);
            BossSpawner3.SetActive(false);
            EnemySpawner2.SetActive(false);
            EnemySpawner3.SetActive(false);
            break;

            case 2: timer = 25f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);
            BossSpawner2.SetActive(true);
            EnemySpawner2.SetActive(true);
            break;

            case 3: timer = 30f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);
            BossSpawner3.SetActive(true);
            EnemySpawner3.SetActive(true);
            break;

            case 4: EndGame();
            gameWon = true;
            break;

            default:
            break;       
         }
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
            DestroyBosses();
            DestroyEnemies();
            gameHasEnded = true;
            HUD.SetActive(false);
            gameOverHUD.SetActive(true);
            BossSpawner1.SetActive(false);
            EnemySpawner1.SetActive(false);
            BossSpawner2.SetActive(false);
            EnemySpawner2.SetActive(false);
            BossSpawner3.SetActive(false);
            EnemySpawner3.SetActive(false);
        }
        
    }

     public void Restart(){
        SceneManager.LoadScene("GameOver");
    }
}
