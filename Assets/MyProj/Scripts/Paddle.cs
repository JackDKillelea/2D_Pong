using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float velSpeed = 2f;
    public int playerIndex = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float verticalMovement = Input.GetAxis("Vertical" + playerIndex);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalMovement*velSpeed); // First number = Horizontal vel, Second is Vertical vel
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    Debug.Log(Input.GetAxis("Vertical"));
        //}
	}
}
