using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManger levelManger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("trigger");
		levelManger.LoadLevel("Win Screen");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("collision");
	}
}
