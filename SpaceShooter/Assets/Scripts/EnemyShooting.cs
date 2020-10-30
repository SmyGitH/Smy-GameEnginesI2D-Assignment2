using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    public GameObject bullet;
    public float fireRate = 2f;
    private float cooldownTimer = 0;
    private float gameTime;


    private void Start() {
        gameTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= gameTime;

        if(cooldownTimer <= 0){
            //shoot
            Debug.Log("Shoot");
            cooldownTimer = fireRate;

            Vector3 offset = transform.rotation * new Vector3(0,0.5f,0);

            Instantiate(bullet, transform.position + offset, transform.rotation);
        }
        
    }
}
