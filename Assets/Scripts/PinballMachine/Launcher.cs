using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour {
  float power;
	float minPower = 0f;
	public float maxPower = 5000f;
	public Slider powerSlider;
	List<Rigidbody> ballList;
	bool ballReady;
  public GameObject cap;


	void Start () {
    powerSlider.minValue = 0f;
		powerSlider.maxValue = maxPower;
		ballList = new List<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
    if (ballReady) {
			powerSlider.gameObject.SetActive(true);
		} else {
			powerSlider.gameObject.SetActive(false);
		}

    powerSlider.value = power;
		if (ballList.Count > 0) {
			ballReady = true;
			if (Input.GetKey(KeyCode.Space)) {
				if (power <= maxPower) {
					power += 100 * Time.deltaTime;
				}
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				foreach(Rigidbody r in ballList) {
					r.AddForce(power * Vector3.forward);
				}
			}
		} else {
			ballReady = false;
			power = 0f;
		}
	}

	private void OnTriggerEnter(Collider o) {
		if (o.gameObject.CompareTag("Ball")) {
			ballList.Add(o.gameObject.GetComponent<Rigidbody>());
      GameObject.FindWithTag("Game").GetComponent<SuperPinball>().gameStartOfficial = false;
      cap.SetActive(false);
		}
	}

	private void OnTriggerExit(Collider o) {
		if (o.gameObject.CompareTag("Ball")) {
			ballList.Remove(o.gameObject.GetComponent<Rigidbody>());
			power = 0f;
		}
	}
}
