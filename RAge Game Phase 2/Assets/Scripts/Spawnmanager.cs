using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Spawnstate
{
    wave1 ,
    wave2 ,
    wave3 ,
    stop
}

public class Spawnmanager : MonoBehaviour {
    private Spawnstate spawnstate = Spawnstate.wave1;
    public GameObject[] spawnObject;
    public Transform [] spawnPosition;
    public Enemycontoller enemy;
    public float Timer = 1;

    // Use this for initialization
    void Start () {
     
         Instantiate(spawnObject[Random.Range(0,3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
         enemy.enemycount = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (enemy.shouldspawn==false)
        {
            spawnstate = Spawnstate.stop;
        }
        else if (enemy.shouldspawn==true && enemy.times==1 )
        {
            spawnstate = Spawnstate.wave2;
        }
        else if (enemy.shouldspawn == true && enemy.times == 2)
        {
            spawnstate = Spawnstate.wave3;
        }
        else if (spawnstate == Spawnstate.wave1)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Wave1spawn();
                Timer = 4f;
            }
        }

        else if (spawnstate == Spawnstate.wave2)
        {        
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Wave2spawn();
                Timer = 2f;
            }
        }

        else if (spawnstate == Spawnstate.wave3)
        {
            
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Wave1spawn();
                Timer = 1f;
            }
        }
       


    }

    void Wave1spawn()
    {
        Instantiate(spawnObject[Random.Range(0, 3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
        enemy.enemycount += 1;
        
    }

    void Wave2spawn()
    {
        Instantiate(spawnObject[Random.Range(0, 3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
        enemy.enemycount += 1;
    }

    void Wave3spawn()
    {
        Instantiate(spawnObject[Random.Range(0, 3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
        enemy.enemycount += 1;
    }
    
    
    



}
