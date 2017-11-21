using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthScript : MonoBehaviour {
  private void OnTriggerEnter(Collider o) {
		if (o.gameObject.CompareTag("Ball")) {
      GameObject.FindWithTag("Game").GetComponent<SuperPinball>().UpdateScore(1000);
			Destroy(GameObject.FindWithTag("Monster"));
		}
	}
}
