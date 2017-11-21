using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour {

	public GameObject cap;

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Ball") {
			cap.SetActive(true);
		}
	}
}
