using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bosspres : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetFloat("Blend", 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetFloat("Blend", 0);
        }
    }
}
