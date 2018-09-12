using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontoller : MonoBehaviour {
    public int enemycount;
    public bool shouldspawn = true;
    public int times = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemycount == 10 )
        {
            shouldspawn = false;
            times += 1;
            
        }
        if (enemycount == 0)
        {
            shouldspawn = true;
        }
        
	}
}
