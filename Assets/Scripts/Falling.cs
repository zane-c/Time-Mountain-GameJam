using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

	private Rigidbody2D rb;
	private TimeDilation time;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		time = GameObject.Find("FatherTime").GetComponent<TimeDilation> ();
	}

	// Update is called once per frame
	void Update () {
		if (time.isTimeFrozen) {
			rb.velocity = new Vector3 (0, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "FallDeath") {
			Destroy(gameObject);
		}
	}
}
