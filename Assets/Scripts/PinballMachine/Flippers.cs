using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour {
  public float resetPosition = 0f;
	public float pressedPosition = 45f;
	public float hitStrength = 500000f;
	public float flipperDamper = 150f;
	HingeJoint hinge;

	public string inputName;
	// Use this for initialization
	void Start () {
    hinge = GetComponent<HingeJoint>();
		hinge.useSpring = true;
	}

	// Update is called once per frame
	void Update () {
		JointSpring spring = new JointSpring();
		spring.spring = hitStrength;
		spring.damper = flipperDamper;

		if (Input.GetAxis(inputName) == 1) {
      spring.targetPosition = pressedPosition;
		} else {
			spring.targetPosition = resetPosition;
		}

		hinge.spring = spring;
		hinge.useLimits = true;
	}
}
