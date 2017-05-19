using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crash;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	public GameObject particle;



	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;	
		}
		timesHit = 0;	
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		particle.transform.position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}


	void HandleHits () {
		timesHit += 1;
		LoadSprites ();
	}


	void OnCollisionEnter2D(Collision2D collision){
		if (isBreakable) {
			HandleHits ();
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if (timesHit >= hitSprites.Length + 1) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			AudioSource.PlayClipAtPoint (crash, transform.position);
			ParticleEffects ();
			Destroy (gameObject);
		} 
	}

	void ParticleEffects(){
		GameObject explosion = Instantiate (particle, gameObject.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem.MainModule explosionmain = explosion.GetComponent<ParticleSystem>().main;
		explosionmain.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}



	//TODO Remove this method once we can actually win.
	void SimulateWin () {
		levelManager.LoadNextLevel ();

	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites.Length > 0) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Sprite not found");
		}
	}
}
