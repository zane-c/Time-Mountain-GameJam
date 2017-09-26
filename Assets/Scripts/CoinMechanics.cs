using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMechanics : MonoBehaviour {

	private TimeDilation time;
	private Animator anim;

	// Use this for initialization
	void Start () {
		time = GameObject.Find("FatherTime").GetComponent<TimeDilation> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (time.watchTime == 0) {
			anim.enabled = false;
		} else {
			anim.enabled = true;
		}
	}
}
