using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacePlayer : MonoBehaviour
{
    private float rotSpeed = 90f;
    private float gameTime;
    private Transform player;
   
   private void Start() {
       gameTime = Time.deltaTime;
   }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            //Find the player
           GameObject go = GameObject.FindWithTag("Player");

           if(go != null){
               player = go.transform;
           }
        }

        if(player == null){
            return;
        }
        //point to player direction

        Vector3 dir = player.position - transform.position;

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler (0,0,zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * gameTime);
    }
}
