using UnityEngine;
using System.Collections;

public class GroundRotate : MonoBehaviour {

	public float moveSpeed = 2.0f;
	public bool rotationActive = true;

	void Update () {
		if(rotationActive) {
			rigidbody2D.velocity = new Vector2((transform.localScale.x * moveSpeed)*-1.0f, rigidbody2D.velocity.y);
			
			if((transform.position.x < -10.0f)) {
				transform.position = new Vector3(17.1f, transform.position.y, transform.position.z);
			}
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
}
