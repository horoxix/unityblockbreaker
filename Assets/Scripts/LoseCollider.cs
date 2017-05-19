using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;


	void OnTriggerEnter2D(Collider2D collider){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("Lose");

	}

	void OnCollisionEnter2D(Collision2D collision){

	}

}
