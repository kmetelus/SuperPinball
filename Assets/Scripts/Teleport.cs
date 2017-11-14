using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour {

  public Transform location;
  private int triggerCount;
  private int toUse;

  void Start() {
    toUse = 1;
    triggerCount = 0;
  }
  private void OnTriggerEnter(Collider o) {
		if (o.gameObject.CompareTag("Ball")) {
      triggerCount++;
			Rigidbody ball = o.gameObject.GetComponent<Rigidbody>();
      if (triggerCount == toUse) {
          ball.position = new Vector3(location.position.x, location.position.y + 0.27f, location.position.z);
          toUse++;
          triggerCount = 0;
      }
		}
	}
}
