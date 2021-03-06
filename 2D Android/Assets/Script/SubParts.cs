﻿using UnityEngine;
using System.Collections;

public class SubParts : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private Color start;
	private Color end;
	private float t = 0.0f;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		start = spriteRenderer.color;
		end = new Color (start.r, start.g, start.b, 0.0f);
	}

	void Update () {
		t += Time.deltaTime;
		renderer.material.color = Color.Lerp (start, end, t / 2);
		
		if (renderer.material.color.a <= 0.0f)
			Destroy (gameObject);
	}
}
