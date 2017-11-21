using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  **STUFF TO DO**
  - Add a teleporter to the right of the pinball machine that will teleport
    the ball to the top of the machine
     > Use box collider + SpawnBall() code
     > Need to make new traforms + randomization inside transform for ball spwan
       location
*/

public class SuperPinball : MonoBehaviour {
  private float t = 0f;
  private float timeToSpawnAMonster = 10.0f;

	public Transform ballZone;
	public Transform ball;
	public int score;
	public Text scoreText;
	public int ballsLeft;
	public Text ballsText;

  public Transform monsterSpawnZone;
  public Transform monster;

	public Text gameOverText;

	Vector3 ballOffset  = new Vector3(0f, 0.5f, 0.5f);

	public void SpawnBall() {
		ballsLeft--;
		ballsText.text = "Balls Left: " + ballsLeft;
	  Instantiate(ball, ballZone.transform.position + ballOffset, Quaternion.identity);
	}

  public void SpawnMonster() {
    Instantiate(monster, monsterSpawnZone.position, Quaternion.identity);
  }


	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Score: 0";
		ballsLeft = 4;
    SpawnBall();
		gameOverText.enabled = false;

	}

  void Update() {
    t += Time.deltaTime;
    if (t >= timeToSpawnAMonster) {
      SpawnMonster();
      t = 0;
    }
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
