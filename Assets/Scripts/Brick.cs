using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;

	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		print ("Breakable bricks in the scene: " + breakableCount);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if(isBreakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.08f);
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			breakableCount--;
			print ("Breakable bricks in the scene: " + breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		GameObject smokePuff = (GameObject) Instantiate(smoke, transform.position, Quaternion.identity);
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
	
	//TODO Remove this method once we can actually win!!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
