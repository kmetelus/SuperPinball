﻿using System.Collections;
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

  public bool gameStartOfficial;
  private bool gameOver;

	public Transform ballZone;
	public Transform ball;
	public int score;
	public Text scoreText;
  private int highScore = 0;
  public Text highScoreText;
	public int ballsLeft;
	public Text ballsText;

  public Transform monsterSpawnZone;
  public Transform monster;

	public Text gameOverText;
  public GameObject playAgainButton;

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
    gameOver = false;
		score = 0;
		scoreText.text = "Score: 0";
    highScoreText.enabled = false;
		ballsLeft = 4;
    SpawnBall();
		gameOverText.enabled = false;
    gameStartOfficial = false;
    playAgainButton.SetActive(false);

	}

  void Update() {
    if (!gameStartOfficial) {
      t = 0;
    } else {
      t += Time.deltaTime;
      if (t >= timeToSpawnAMonster) {
        SpawnMonster();
        t = 0;
      }
    }

    if (Input.GetKeyDown(KeyCode.C) && gameOver) {
      PlayAgain();
    }
  }

	public void UpdateScore(int i) {
		score += i;
		scoreText.text = "Score: " + score;
    if (score >= highScore) {
      highScore = score;
      highScoreText.text = "High Score: " + highScore;
    }
	}

	public void GameOver() {
     gameOver = true;
		 gameOverText.text = "GAME OVER \n SCORE: " + score + " \n HIGH SCORE: " + highScore;
     gameOverText.enabled = true;
		 scoreText.enabled = false;
		 ballsText.enabled = false;
     highScoreText.enabled = false;
     playAgainButton.SetActive(true);
	}

  public void PlayAgain() {
    foreach(GameObject x in GameObject.FindGameObjectsWithTag("Monster")) {
      Destroy(x);
    }
    Start();
    scoreText.enabled = true;
    ballsText.enabled = true;
    highScoreText.enabled = true;
    highScoreText.text = "High Score: " + highScore;
  }
}
