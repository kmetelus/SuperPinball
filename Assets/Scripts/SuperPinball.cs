using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Quaternion;

public class SuperPinball : MonoBehaviour {

	public Transform ballZone;
	public Transform ball;
	public int score;
	public Text scoreText;
	public int ballsLeft;
	public Text ballsText;

	public Text gameOverText;

	Vector3 ballOffset  = new Vector3(0f, 0.5f, 0.5f);

	public void SpawnBall() {
		ballsLeft--;
		ballsText.text = "Balls Left: " + ballsLeft;
	  Instantiate(ball, ballZone.transform.position + ballOffset, Quaternion.identity);
	}


	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Score: 0";
		ballsLeft = 4;
    SpawnBall();
		gameOverText.enabled = false;

	}

	public void UpdateScore(int i) {
		score += i;
		scoreText.text = "Score: " + score;
	}

	// Update is called once per frame
	public void GameOver() {
		 gameOverText.text = "GAME OVER \n SCORE: " + score;
     gameOverText.enabled = true;
		 scoreText.enabled = false;
		 ballsText.enabled = false;
	}
}
