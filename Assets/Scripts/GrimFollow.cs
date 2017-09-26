using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimFollow : MonoBehaviour {

	private TimeDilation time;
	private Transform player;
	private float speed = 2.0f;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
		time = GameObject.Find("FatherTime").GetComponent<TimeDilation> ();
	}

	// Update is called once per frame
	void Update () {
		float xSpeed;
		float ySpeed;

		if (transform.position.x < player.position.x) {
			xSpeed = speed;
		} else {
			xSpeed = -1 * speed;
		}

		if (transform.position.y < player.position.y) {
			ySpeed = speed;
		} else {
			ySpeed = -1 * speed;
		}

		transform.Translate (new Vector3 (xSpeed * time.watchTime, ySpeed * time.watchTime, 0));

		if (xSpeed > 0 && !facingRight) {
			Flip();
		} else if (xSpeed < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
