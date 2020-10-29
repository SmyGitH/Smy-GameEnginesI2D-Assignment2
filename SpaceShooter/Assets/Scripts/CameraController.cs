using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform myTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget != null){
            
            Vector3 targPos = myTarget.transform.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
    }
}
