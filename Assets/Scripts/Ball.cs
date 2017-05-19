using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	private Paddle paddle;
	private bool hasStarted = false;
	private Rigidbody2D rigi;
	private Vector3 paddleToBallVector;
	private AudioSource audio;

	void Awake () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		rigi = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;	
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				rigi.velocity = new Vector2(1f, 12f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 adjust = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			rigi.velocity += adjust;
			print (transform.position);
		}
	}
}
