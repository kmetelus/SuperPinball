using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : MonoBehaviour {

  public GameObject game;

	void OnCollisionEnter(Collision c) {
		float force = 1.0f;
		if (c.gameObject.tag == "Ball") {
			Debug.Log("Collision with Ball");
			Vector3 dir = transform.position;
			Debug.Log("Before: " + dir);
			dir = -dir.normalized;
			Debug.Log("After: " + dir);
			c.rigidbody.AddForce(dir.x * force, 0f, dir.z * force, ForceMode.Impulse);
			game.GetComponent<SuperPinball>().UpdateScore(100);
		}

	}
}
