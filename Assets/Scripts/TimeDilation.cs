using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDilation : MonoBehaviour {

	public GameObject player;
	private PlayerController pc;
	private Animator anim;
	public Camera cam;
	public Text timeUi;
	public float watchTime = 0;
	public bool isTimeFrozen = false;
	private float timeOnWatch = 30.0f;

	// audio
  private AudioSource slowmo;
  private AudioSource music;
  AudioClip slow;
  AudioClip fast;
  AudioSource tick;

    // Use this for initialization
    void Start () {
			anim = player.GetComponent<Animator> ();
			cam.gameObject.SetActive (false);
			pc = player.GetComponent<PlayerController> ();

			anim.SetBool("isTimeFrozen", isTimeFrozen);
			anim.SetFloat("timeOnWatch", timeOnWatch);
			int time = (int)timeOnWatch;
			timeUi.text = time.ToString();

			slowmo = player.GetComponent<AudioSource>();
            GameObject Cam = GameObject.Find("Main Camera");
            GameObject Coin = GameObject.Find("CoinSound");
    
            music = Cam.GetComponent<AudioSource>();
            tick = Coin.GetComponent<AudioSource>();
            slow = (AudioClip)Resources.Load("slowmo_a");
            fast = (AudioClip)Resources.Load("fastmo_a");
     
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			isTimeFrozen = !isTimeFrozen;
			anim.SetBool("isTimeFrozen", isTimeFrozen);
	    if (isTimeFrozen) {
	        slowmo.PlayOneShot(slow);
	        music.volume = 0.1f;
            tick.Play();
	       
	    } else {
	        slowmo.PlayOneShot(fast);
            tick.Pause();
	        music.volume = 0.3f;
	    }
	  }

		if (isTimeFrozen && !cam.gameObject.activeSelf) {
			cam.gameObject.SetActive (true);
		} else if (!isTimeFrozen && cam.gameObject.activeSelf) {
			cam.gameObject.SetActive (false);
		}

		if (!isTimeFrozen) {
			watchTime = Time.deltaTime;
		} else {
			watchTime = 0;
			timeOnWatch -= Time.deltaTime;
			int time = (int)timeOnWatch;
			timeUi.text = time.ToString();
		}
		anim.SetFloat("timeOnWatch", timeOnWatch);
		if (timeOnWatch < 0) {
			pc.Death ();
		}
	}
}
