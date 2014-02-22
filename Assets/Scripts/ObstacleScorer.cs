using UnityEngine;
using System.Collections;

public class ObstacleScorer : MonoBehaviour {

	private UserInterface userInterface;

	// Use this for initialization
	void Awake () {
		userInterface = GameObject.Find("UI").GetComponent<UserInterface>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collide) {
		userInterface.AddScore();
	}
}
