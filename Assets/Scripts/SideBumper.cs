using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : MonoBehaviour {

  public GameObject game;

	void OnCollisionEnter(Collision c) {
		float force = 1.0f;
		if (c.gameObject.tag == "Ball") {
			Vector3 dir = transform.position;
			dir = -dir.normalized;
			c.rigidbody.AddForce(dir.x * force, 0f, dir.z * force, ForceMode.Impulse);
			game.GetComponent<SuperPinball>().UpdateScore(100);
		}

	}
}
