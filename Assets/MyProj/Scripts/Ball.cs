using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody2D ballRigidBody;

	// Use this for initialization
	void Start () {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.velocity = new Vector2(-0.2f, speed);
	}
	
	// Update is called once per frame
	void Update () { 

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking for collision on the Limit tag.
        if (collision.tag == "Limit")
        {   // Collided with the top limit tag.
            if (collision.transform.position.y > transform.position.y && ballRigidBody.velocity.y > 0)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
            // Collided with the lower limit tag.
            if (collision.transform.position.y < transform.position.y && ballRigidBody.velocity.y < 0)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
            // Checking for collision on the Paddle tag.
            else if (collision.tag == "Paddle")
            {   // Collided with the left Paddle.
                if (collision.transform.position.x < transform.position.x && ballRigidBody.velocity.x < 0)
                {
                    Debug.Log("Collision");
                    ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x, ballRigidBody.velocity.y);
                }
                // Collided with the right Paddle.
                if (collision.transform.position.x > transform.position.x && ballRigidBody.velocity.x > 0)
                {
                    Debug.Log("Collision");
                    ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x, ballRigidBody.velocity.y);
                }
                //Debug.Log("Collision Successful.");
            }
        }
    }
}
