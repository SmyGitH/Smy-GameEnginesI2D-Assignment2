using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
   public int health;
  private float invulnerableTimer;
  private int correctLayer;
  public float invulnerablePeriod;
  private SpriteRenderer sprite;
  private Animator animator;
  public GameObject deathParticle;
  public bool weaponsUp;
  public bool speedUp;
  public bool shieldUp;
  public float powerTimer;
  private float gameTime;

  private PlayerShooting playerShoot;
  private PlayerController playerMove;
  private GameManager gameManager;
  private SoundManager soundManager;
  

  private void Start() {

      correctLayer = gameObject.layer;

      sprite = GetComponent<SpriteRenderer>();
      playerShoot = gameObject.GetComponent<PlayerShooting>();
      playerMove = gameObject.GetComponent<PlayerController>();
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      animator = GameObject.Find("DamageF").GetComponent<Animator>();
      soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();

      gameTime = Time.deltaTime;

      if(sprite == null){
          sprite = transform.GetComponentInChildren<SpriteRenderer>();

          if(sprite == null){
              Debug.Log("Object " + gameObject.name + "has no sprite renderer");
          }
          
      }
  }

  private void OnTriggerEnter2D(Collider2D other) {

      if(other.gameObject.layer == 9 || other.gameObject.layer == 12 || other.gameObject.layer == 13){
          health--;

          if(health > 0){
              invulnerableTimer = invulnerablePeriod;
          }
          
          
      }

      if(other.gameObject.layer == 8){
          animator.SetBool("Damaged", true);
          invulnerableTimer = invulnerablePeriod;
          health--;
          
      }

      if(other.gameObject.tag == "WeaponUp"){
          weaponsUp = true;
          Destroy(other.gameObject);
          powerTimer = 10f;
          soundManager.PowerUpSound.Play();
      }else if(other.gameObject.tag == "SpeedUp"){
          speedUp = true;
          Destroy(other.gameObject);
          powerTimer = 10f;
          soundManager.PowerUpSound.Play();
      }else if (other.gameObject.tag == "ShieldUp"){
          health++;
          Destroy(other.gameObject);
          soundManager.PowerUpSound.Play();
      } 
    
  }

  private void Update() {

      if(weaponsUp){
          playerShoot.fireRate = 0.5f;
          powerTimer -= gameTime / 5;
          if(powerTimer <= 0){
              weaponsUp = false;
              playerShoot.fireRate = 0.75f;
          }
      }

      if(speedUp){
          powerTimer -= gameTime / 5;
          playerMove.maxSpeed = 12f;
          if(powerTimer <= 0){
              speedUp = false;
              playerMove.maxSpeed = 10f;
          }
      }
  }

  private void FixedUpdate() {

      if(invulnerableTimer > 0){
         invulnerableTimer -= gameTime;
         Blinking();
         gameObject.layer = 10;
      }

     
      if(invulnerableTimer <= 0) {
          gameObject.layer = correctLayer;
          sprite.enabled = true;
      }


      if (health <= 0){
          Die();
          
      }
  }

  private void OnDestroy() {
      if(gameObject.layer == 9){
          if(soundManager != null){
              soundManager.deathSound.Play();
              if(soundManager == null){
                  soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();
                  soundManager.deathSound.Play();
              }
          }
            
            Instantiate(deathParticle,transform.position,transform.rotation);
          }
          
      if(gameObject.layer == 8){
          soundManager.deathSound.Play();
          gameManager.EndGame();
          gameManager.gameLost = true;
         }
      }


  private void Die(){
      if(gameObject.tag == "Enemy"){
          Destroy(gameObject);
          gameManager.score += 150;
          
      }

      if(gameObject.tag == "Boss"){
          Destroy(gameObject);
          gameManager.score += 300;
          
      }

      if(gameObject.layer == 12 || gameObject.layer == 13){
          Destroy(gameObject);
      }

      if(gameObject.layer == 8  || gameObject.layer == 10){
          Destroy(gameObject);
          
      }
      
  }

  private void Blinking(){
      if(sprite.enabled == true){
          sprite.enabled = false;
      }else{
          sprite.enabled = true;
      }
  }

}
