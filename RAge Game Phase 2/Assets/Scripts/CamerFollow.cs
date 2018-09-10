using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    private Vector3 rotateoffset;
    Camera mycam;
    public float speed;
    // Use this for initialization
    void Start () {

        offset = transform.position - player.transform.position;
         
    }
	
	// Update is called once per frame
	void LateUpdate () {
       transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;  
       
    }
    

    
}
