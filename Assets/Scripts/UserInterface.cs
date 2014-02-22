using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour {

	public GUIText currentScore;
	public GUIText highScore;
	public GUIText retryMessage;

	private int score = 0;

	// Use this for initialization
	void Awake () {
		if(highScore) {
			int high = PlayerPrefs.GetInt("highscore");
			highScore.text = "High: " + high;
		}

		if(Application.loadedLevelName == "Game") {
			retryMessage.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "Menu") {
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel("Game");
			}
		}
	}

	public void AddScore() {
		score += 1;
		currentScore.text = "Score: " + score;
	}

	public void SaveScore() {
		int prev = PlayerPrefs.GetInt("highscore");
		if(score > prev) {
			PlayerPrefs.SetInt("highscore", score);
			highScore.text = "High: " + score;
		}

		retryMessage.enabled = true;
	}
}
