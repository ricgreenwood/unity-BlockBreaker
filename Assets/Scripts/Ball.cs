using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	
	private Vector3 PaddleToBallVector;

	// Use this for initialization
	void Start () {
		PaddleToBallVector = this.transform.position - paddle.transform.position;
		print (PaddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
