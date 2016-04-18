﻿using UnityEngine;
//using CnControls;
using System.Collections;

public class CloudController : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float MaxSpeed;
	public float speedFactor;
	private Rigidbody2D rb2d;
	public VirtualJoystick joystick;
	public HeroTransform heroTransform;
	public bool m_Grounded = true;
	//Use the two store floats to create a new Vector2 variable movement.
	private Vector2 movement;
	public GameObject cloudObject;
	public int i;
	private bool isCloud = true;



	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
		isCloud = true;

	}

	void Start () {

		//rb2d.drag = 0.5f;
		m_Grounded=false;
		MaxSpeed =5f;
		speed = 20f;
		speedFactor = 5f;
		i = 0;

	}


	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal") * speedFactor;

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical") * speedFactor;

		movement = new Vector2 (moveHorizontal, moveVertical); 

		movement.x = joystick.Horizontal () * speedFactor;

		movement.y = joystick.Vertical () * speedFactor;

		float moveMag = movement.magnitude;

		if ( moveMag > MaxSpeed) {
			movement = movement * MaxSpeed / moveMag; 
		}

		rb2d.velocity = new Vector2 (movement.x , movement.y);

		bool isBtnClick = heroTransform.isCloudTransform;

		if (isBtnClick) {
			heroTransform.isCloudTransform = false;
			isBtnClick = false;
			isCloud = !isCloud;
			if (!isCloud) {
				Debug.Log ("Cloud Disappear!!!!");
				//cloudObject.SetActive (false);
				//Destroy(cloudObject);
				transform.position = new Vector3 (0f, 0f, 0f);
			} else {
				Debug.Log ("Cloud re-appear!!!!");
				//GameObject cloudObject = GameObject.Find ("CloudBall");
				//cloudObject.SetActive (true);
				transform.position = new Vector3 (-7f, -2f, 0f);
				//GameObject.Instantiate(cloudObject,transform.position/* new Vector3(5.6f,12.5f,0f)*/,Quaternion.identity);
			}

		}
	}

}
