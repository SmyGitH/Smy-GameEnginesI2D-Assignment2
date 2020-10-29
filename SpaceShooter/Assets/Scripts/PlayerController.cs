using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float maxSpeed = 5f;
    private float rotSpeed = 180f;
    private float shipBoundaries = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
        //Rotating the ship
        Quaternion rot = transform.rotation;
        float  playerZ = rot.eulerAngles.z;

        playerZ -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0,0,playerZ);
        transform.rotation = rot;


        //Move the ship around
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3 (0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        //Restricting player boundaries
        if (pos.y + shipBoundaries > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - shipBoundaries;
        }
        if(pos.y - shipBoundaries < -Camera.main.orthographicSize){
             pos.y = -Camera.main.orthographicSize + shipBoundaries;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaries > widthOrtho){
            pos.x = widthOrtho - shipBoundaries;
        }
        if(pos.x - shipBoundaries < -widthOrtho){
             pos.x = -widthOrtho + shipBoundaries;
        }

        transform.position = pos;
    }
}
