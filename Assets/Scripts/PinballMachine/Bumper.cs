using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

	public GameObject game;

	void OnCollisionEnter(Collision c) {
    if (c.gameObject.tag == "Ball") {
			game.GetComponent<SuperPinball>().UpdateScore(50);
    }
  }
}
