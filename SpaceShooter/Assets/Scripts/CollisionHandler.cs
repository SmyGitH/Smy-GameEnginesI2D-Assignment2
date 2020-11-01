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
  public bool weaponsUp;
  public bool speedUp;
  public bool shieldUp;
  public float powerTimer;
  private float gameTime;

  private PlayerShooting playerShoot;
  private PlayerController playerMove;
  public Score scoreScript;

  private void Start() {

      correctLayer = gameObject.layer;

      sprite = GetComponent<SpriteRenderer>();
      playerShoot = gameObject.GetComponent<PlayerShooting>();
      playerMove = gameObject.GetComponent<PlayerController>();
      scoreScript = gameObject.GetComponent<Score>();

      gameTime = Time.deltaTime;

      if(sprite == null){
          sprite = transform.GetComponentInChildren<SpriteRenderer>();

          if(sprite == null){
              Debug.Log("Object " + gameObject.name + "has no sprite renderer");
          }
          
      }
  }

  private void OnTriggerEnter2D(Collider2D other) {

      if(other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 12 || other.gameObject.layer == 13){
          health--;
          invulnerableTimer = invulnerablePeriod;
      }

      if(other.gameObject.tag == "WeaponUp"){
          weaponsUp = true;
          Destroy(other.gameObject);
          powerTimer = 5f;
      }else if(other.gameObject.tag == "SpeedUp"){
          speedUp = true;
          Destroy(other.gameObject);
          powerTimer = 5f;
      }else if (other.gameObject.tag == "ShieldUp"){
          health++;
          Destroy(other.gameObject);
      } 
    
  }

  private void Update() {

      

      if(weaponsUp){
          playerShoot.fireRate = 0.5f;
          powerTimer -= gameTime / 2;
          if(powerTimer <= 0){
              weaponsUp = false;
              playerShoot.fireRate = 0.75f;
          }
      }

      if(speedUp){
          powerTimer -= gameTime / 2;
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

  private void Die(){
      if(gameObject.tag == "Enemy"){
          Destroy(gameObject);
          scoreScript.score += 150;
      }

      if(gameObject.tag == "Boss"){
          Destroy(gameObject);
          scoreScript.score += 300;
      }

      if(gameObject.layer == 8 || gameObject.layer == 12 || gameObject.layer == 13){
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
