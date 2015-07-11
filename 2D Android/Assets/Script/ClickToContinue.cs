﻿using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {

	public string scene;
	private bool loadLock;

	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadLock)
			LoadScene ();
	}

	void LoadScene(){
		loadLock = true;
		Application.LoadLevel (scene);
		Life.air = 10;
	}
}
