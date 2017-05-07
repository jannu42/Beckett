﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform Player;

	// Update is called once per frame
	void Update () {

		// Pausemenu aukeaa jos painetaa Escape
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
			} else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
			}
		}
	}
}
