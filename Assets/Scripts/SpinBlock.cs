using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBlock : MonoBehaviour {

	private TimeDilation time;
	private float speed = 80f;

	// Use this for initialization
	void Start () {
		time = GameObject.Find("FatherTime").GetComponent<TimeDilation> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, speed * time.watchTime);
	}
}
