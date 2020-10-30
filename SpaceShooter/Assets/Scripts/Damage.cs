using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
  public int health = 1;
  private float invulnerableTimer;
  private int correctLayer;
  public float invulnerablePeriod;
  private SpriteRenderer sprite;

  private void Start() {
      correctLayer = gameObject.layer;

      sprite = GetComponent<SpriteRenderer>();

      if(sprite == null){
          sprite = transform.GetComponentInChildren<SpriteRenderer>();

          if(sprite == null){
              Debug.Log("Object " + gameObject.name + "has no sprite renderer");
          }
          
      }
  }

  private void OnTriggerEnter2D(Collider2D other) {

          health--;
          invulnerableTimer = invulnerablePeriod;
          gameObject.layer = 10;
    
  }

  private void FixedUpdate() {

      if(invulnerableTimer > 0){
         invulnerableTimer -= Time.deltaTime;
         Blinking();
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
      Destroy(gameObject);
  }

  private void Blinking(){
      if(sprite.enabled == true){
          sprite.enabled = false;
      }else{
          sprite.enabled = true;
      }
  }

}
