using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	public GameObject game;
	private SuperPinball sp;

	void Start() {
		sp = game.GetComponent<SuperPinball>();
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Ball") {
			Destroy(c.gameObject);
			if (sp.ballsLeft > 0) {
				sp.SpawnBall();
			} else {
				sp.GameOver();
			}
		}
	}
}
