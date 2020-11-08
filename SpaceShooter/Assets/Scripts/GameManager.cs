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
    [HideInInspector] public bool gameHasEnded = false;
    [HideInInspector] public bool gameLost = false;
    [HideInInspector] public bool gameWon = false;
    private Animator levelFlash;
    private Text levelText;
    private Animator damageFlash;
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
        EnemySpawner2 = GameObject.Find("EnemySpawner2");
        EnemySpawner3 = GameObject.Find("EnemySpawner3");
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


        switch(level){
            case 1: timer = 25f;
            DestroyBosses();
            DestroyEnemies();
            levelFlash.SetBool("LevelSwitch", true);
            gameOverHUD.SetActive(false);
            BossSpawner2.SetActive(false);
            BossSpawner3.SetActive(false);
            EnemySpawner2.SetActive(false);
            EnemySpawner3.SetActive(false);
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

            case 4: EndGame();
            gameWon = true;
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


    public void EndGame(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            HUD.SetActive(false);
            gameOverHUD.SetActive(true);
        }
        
    }

     public void Restart(){
        SceneManager.LoadScene("GameOver");
    }
}
