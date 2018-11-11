using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	CharacterController charCont ;
	[SerializeField]
	float speed = 0;

	[SerializeField]
	float jump = 0; 
	float yVelocity = 0;

	bool controlling = true ;

	[SerializeField]
	Vector3 move = new Vector3();
	Vector3 v3 = new Vector3();

	void Start ()
	{
		charCont = GetComponent<CharacterController> ();
	}

	void FixedUpdate()
	{
		if (charCont.isGrounded) 
		{
			yVelocity = 0;
			if (Input.GetKey (KeyCode.W) && controlling) 
			{
				yVelocity = jump;
			}
		}
		if (!charCont.isGrounded) {
			yVelocity += Physics.gravity.y * Time.fixedDeltaTime;
		} 

		v3.Set (Input.GetAxis("Horizontal") * speed,yVelocity,0);
		move = v3;
		charCont.Move (move*Time.fixedDeltaTime);
	}
}
