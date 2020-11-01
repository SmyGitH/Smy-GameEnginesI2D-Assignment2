using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
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
            Instantiate(bossPrefab, transform.position, transform.rotation);
            spawnTimer = 60f;
        }
        
    }
}
