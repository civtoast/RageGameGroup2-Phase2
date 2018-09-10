using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {

    public bool lockcursor;
    public float mousesensitivity = 10f;
    public Transform target;
    public float targetdist;
    public Vector2  pitchminmax = new Vector2 (-40,85);

    public float rotationsmoothtime = .12f;
    Vector3 rotationsmoothvelocity;
    Vector3 curentrotation;

    float yaw;
    float pitch;
    void Start () {
        if (lockcursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        yaw += Input.GetAxis("Mouse X") * mousesensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mousesensitivity;
        pitch = Mathf.Clamp(pitch, pitchminmax.x, pitchminmax.y);

        curentrotation = Vector3.SmoothDamp(curentrotation, new Vector3(pitch, yaw), ref rotationsmoothvelocity, rotationsmoothtime);
        transform.eulerAngles = curentrotation;

        transform.position = target.position - transform.forward * targetdist;
    }
}
