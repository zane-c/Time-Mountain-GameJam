using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public Button yourButton;
	private Color color;
	private int scale = 1;

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
		SceneManager.LoadScene ("Level 1");
	}
}
