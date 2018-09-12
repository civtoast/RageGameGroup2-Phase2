using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmanager : MonoBehaviour {
    public GameObject[] spawnObject;
    public Transform [] spawnPosition;

    // Use this for initialization
    void Start () {
     
         Instantiate(spawnObject[Random.Range(0,3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
