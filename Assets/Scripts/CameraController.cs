using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;   //Is going to be linked to the Player in the inspector
    public float smoothing = 5f;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
	}
	
	// Waits for physics before updating the frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime); //allows us to move from one object to another
        // smoothing multiplied by deltaTime so that it's frame independent
	}
}
