using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public Button yourButton;
	public Text intro;
	public Text btnText;
	private Color color;
	private int scale = 1;
	private int index = 0;
	private string[] texts = {
		"You are a treasure hunter who comes across a strange watch with a hidden secret. This is no ordinary watch, no... this watch allows you to travel through time.",
		"However, there is a catch: the more you use it to freeze time around you, the more time passes for you.",
		"After a little use, you quickly notice how much you've aged. And, in no time at all you will be older than your grandma.",
		"To remedy this situation, without giving up the great power of the watch, you decide to go after one of the most famous treasures of all, the Fountain of Youth -- for only that will allow you to use the watch without consequence.",
		"You make your way to the black market and buy an old treasure map from a shifty-eyed man. He explains that the map leads to a place far away from here that the indigenous tribes call \"Time Mountain\". At the top is rumored to be the Fountain of Youth.",
		"\"Although, no one who has set out for the mountain, has ever returned...\" he adds.",
		"\"What, can't climb a little mountain?\" you scoff.",
		"The old man looks passed your naivety and calmly remarks, \"Those who wish to cheat Death, must meet Death.\"",
		"Having had enough of the man's old wise-tales, you hand him a small sack in exchange for the map and depart at once. Soon after departing the dark lit alleyways of the black market, you feel a presence following you.",
		"You check your shoulder twice but see no one. You set out for Time Mountain.",
	};

	void Start() {
		yourButton.onClick.AddListener(TaskOnClick);
		color = gameObject.GetComponent<Text> ().color;
	}

	void Update() {
		color = gameObject.GetComponent<Text> ().color;

		if (color.a < 0 && scale < 0) {
			scale = 1;
		} else if (color.a > 1 && scale > 0){
			scale = -1;
		}
		gameObject.GetComponent<Text>().color = new Color (color.r, color.g, color.b, color.a + scale * Time.deltaTime);
	}

	void TaskOnClick() {
		if (index < 9) {
			btnText.text = "Next";
		} else {
			btnText.text = "Play";
		}
		if (index == 10) {
			SceneManager.LoadScene ("Level 1");
		} else {
			intro.text = texts [index];
			index++;
		}
	}
}
