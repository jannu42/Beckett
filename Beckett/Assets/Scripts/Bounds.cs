using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

	private BoxCollider2D bounds;
	private CameraController theCamera;

	// Use this for initialization
	void Start () {
		//Bounds for the camera
		bounds = GetComponent<BoxCollider2D> ();
		theCamera = FindObjectOfType<CameraController> ();
		theCamera.SetBounds (bounds);
	}

}
