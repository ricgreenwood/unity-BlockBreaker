﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse() {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3(Mathf.Clamp (mousePosInBlocks, 1.0f, 15.0f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		float ballPos = ball.transform.position.x;
		Vector3 paddlePos = new Vector3(Mathf.Clamp (ballPos, 1.0f, 15.0f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}
}
