﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager.LoadLevel("Lose Screen");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("collision");
	}
}
