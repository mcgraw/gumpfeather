using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float moveSpeed = 2.0f;
	public float maxHorizontalSpeed = 4.0f;
	public bool obstacleActive = true;

	public SpriteRenderer obstacleTop;
	public SpriteRenderer obstacleBottom;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(obstacleActive) {
			rigidbody2D.velocity = new Vector2((transform.localScale.x * moveSpeed)*-1.0f, rigidbody2D.velocity.y);

			if((tag == "Obstacle" && transform.position.x < 0.0f) || (tag == "Enemy" && transform.position.x < -8.0f)) {
				Destroy(gameObject);
			}

			if(tag == "Enemy") {
				if(transform.position.x < 5.0f && !audio.isPlaying && obstacleActive) {
					playAudio();
				}
			}
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
	
	public void stopObstacle() {
		obstacleActive = false;
	}

	private void playAudio() {
		AudioSource[] sources =  FindObjectsOfType<AudioSource>();
		foreach(AudioSource audioS in sources) {
			audioS.Stop();
		}
		audio.Play();
	}
}
