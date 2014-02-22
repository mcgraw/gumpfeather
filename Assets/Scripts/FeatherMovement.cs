using UnityEngine;
using System.Collections;

public class FeatherMovement : MonoBehaviour {
	
	public float moveForce = 4000f;
	public float maxVerticalSpeed  = 5f;
	public bool featherActive = true;
	public bool grounded = false;

	public Spawner spawner;
	public GroundRotate pieceOne;
	public GroundRotate pieceTwo;

	private Transform groundCheck;

	void Awake() {
		groundCheck = transform.Find("groundCheck");
	}

	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if(grounded && featherActive) {
			death();
		}

		UpdatePosition();

		if(!featherActive) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(featherActive && collider.tag == "Untagged") {
			death();
		}
	}

	private void death() {
		if(featherActive && !audio.isPlaying) {
			playAudio();
		}

		spawner.stopSpawner();
		pieceOne.rotationActive = false;
		pieceTwo.rotationActive = false;
		featherActive = false;

		UserInterface score = GameObject.Find("UI").GetComponent<UserInterface>();
		score.SaveScore();
	}

	/* Flap Feather, Flap!
	 */
	private void UpdatePosition() {
		if(featherActive && transform.position.y < 5.0f) {
			if(Input.GetKeyDown(KeyCode.UpArrow)) {
				rigidbody2D.AddForce(new Vector2(0.0f, moveForce * maxVerticalSpeed));
			} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
				rigidbody2D.AddForce(new Vector2(0.0f, (moveForce * maxVerticalSpeed) * -1.0f));
			}
		}
	}

	private void playAudio() {
		AudioSource[] sources =  FindObjectsOfType<AudioSource>();
		foreach(AudioSource audioS in sources) {
			audioS.Stop();
		}
		audio.Play();
	}
}
