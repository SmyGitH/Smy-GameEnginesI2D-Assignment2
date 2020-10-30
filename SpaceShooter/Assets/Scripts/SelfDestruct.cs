using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destroyTimer = 1f;
    private float gameTime;

    private void Start() {
        gameTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= gameTime;

        if(destroyTimer <= 0){
            Destroy(gameObject);
        }
    }
}
