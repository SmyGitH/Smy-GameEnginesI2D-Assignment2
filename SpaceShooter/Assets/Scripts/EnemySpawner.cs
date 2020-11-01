using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float gameTime;
    public float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= gameTime;

        if(spawnTimer <= 0){
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            spawnTimer = 20f;
        }
        
    }
}
