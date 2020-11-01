using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerUps;
    public Transform spawnLocation;
    private float spawnTimer = 10f;
    private float gameTime;
    public bool spawn;
    void Start()
    {
        gameTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0){
            spawn = true;
        }

        if(spawn){
            SpawnPowerUp();
            spawn = false;
            spawnTimer = 25f;
        }

    }

    private void SpawnPowerUp(){
        Instantiate(powerUps[Random.Range(0,powerUps.Length)],spawnLocation.position, spawnLocation.rotation);
    }
}
