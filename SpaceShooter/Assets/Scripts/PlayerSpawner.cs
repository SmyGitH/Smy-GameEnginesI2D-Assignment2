using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject playerPos;
    public float respawnTimer;
    private float gameTime;
    // Start is called before the first frame update
    void Start()
    {
      gameTime = Time.deltaTime;
      SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos == null){
            respawnTimer -= gameTime;

            if(respawnTimer <= 0){
                 SpawnPlayer();
            }
           
        }
        
    }

    private void SpawnPlayer(){
         respawnTimer = 1f;
         playerPos = Instantiate(player, transform.position, Quaternion.identity);
    }
}
