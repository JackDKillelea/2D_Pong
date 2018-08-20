using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Speed on X Axis.
    public float minXSpeed = 0.75f;
    public float maxXSpeed = 1.6f;

    // Speed on Y Axis.
    public float minYSpeed = 0.75f;
    public float maxYSpeed = 1.6f;

    // This will increase the difficulty whenever the Ball hits a Paddle.
    public float difficultyMultiplier = 1.1f;

    private Rigidbody2D ballRigidBody;

	// Use this for initialization
	void Start () {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1), Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1));
	}
	
	// Update is called once per frame
	void Update () { 

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking for collision on the Paddle tag.
        if (collision.tag == "Paddle")
        {
            // Play the audio clip every time the ball hits a Paddle tag.
            GetComponent<AudioSource>().Play();

            // Collided with the left Paddle.
            if (collision.transform.position.x < transform.position.x && ballRigidBody.velocity.x < 0)
            {
                Debug.Log("Collision");
                ballRigidBody.velocity = new Vector2(
                    -ballRigidBody.velocity.x * difficultyMultiplier, 
                    ballRigidBody.velocity.y * difficultyMultiplier);
            }
            // Collided with the right Paddle.
            if (collision.transform.position.x > transform.position.x && ballRigidBody.velocity.x > 0)
            {
                Debug.Log("Collision");
                ballRigidBody.velocity = new Vector2(
                    -ballRigidBody.velocity.x * difficultyMultiplier,
                    ballRigidBody.velocity.y * difficultyMultiplier);
            }
        }

        // Checking for collision on the Limit tag.
        if (collision.tag == "Limit")
        {
            // Play the audio clip every time the ball hits a Limit tag.
            GetComponent<AudioSource>().Play();
            
            // Collided with the top limit tag.
            if (collision.transform.position.y > transform.position.y && ballRigidBody.velocity.y > 0)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
            // Collided with the lower limit tag.
            if (collision.transform.position.y < transform.position.y && ballRigidBody.velocity.y < 0)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }            
        }
    }
}
