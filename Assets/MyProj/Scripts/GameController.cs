﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject ballPrefab;
    public Text score1Text;
    public Text score2Text;
    public float scoreCoords = 3.3f;

    private Ball currentBall;
    private int score1 = 0;
    private int score2 = 0;

	// Use this for initialization
	void Start () {
        SpawnBall();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentBall != null)
        {   // If the ball goes past the right side player 1 games a point, the current ball is also destroyed to save memory.
            if(currentBall.transform.position.x > scoreCoords)
            {
                score1++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
            // If the ball goes past the left side player 2 games a point, the current ball is also destroyed to save memory.
            if (currentBall.transform.position.x < -scoreCoords)
            {
                score2++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
        }
	}

    // Method to create a ball and set the text
    void SpawnBall()
    {
        GameObject ballInst = Instantiate(ballPrefab, transform);

        currentBall = ballInst.GetComponent<Ball>();
        currentBall.transform.position = Vector3.zero;

        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }
}
