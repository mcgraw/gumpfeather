using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float spawnTime = 2.5f;		// The amount of time between each spawn.
	public float spawnDelay = 3.0f;		// The amount of time before spawning starts.
	public GameObject[] obstacles;		// Array of obstacle prefabs.
	public bool spawnerActive = true;
	
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void Spawn () {
		int obstacleIndex = Random.Range(0, obstacles.Length);

		float randY = Random.Range(-0.4F, -4.6F);
		Instantiate(obstacles[obstacleIndex], new Vector3(20.0f, randY, 0.0f), transform.rotation);
	}

	public void stopSpawner() {
		if(spawnerActive) {
			spawnerActive = false;
			CancelInvoke("Spawn");

			stopMovementWithTag("Obstacle");
			stopMovementWithTag("Enemy");
		}
	}

	private void stopMovementWithTag(string tag) {
		GameObject[] activeObstacles = GameObject.FindGameObjectsWithTag(tag);
		foreach(GameObject ob in activeObstacles) {
			Obstacle component = ob.GetComponent<Obstacle>();
			component.stopObstacle();
		}
	}
}
