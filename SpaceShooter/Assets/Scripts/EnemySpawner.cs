using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float gameTime;
    private float spawnTimer;
    public float difficultySpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = Time.deltaTime;
        spawnTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= gameTime;

        if(spawnTimer <= 0){
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            spawnTimer = difficultySpawnTimer;
        }
        
    }
}
