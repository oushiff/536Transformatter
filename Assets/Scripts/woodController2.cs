using UnityEngine;
using System.Collections;

public class woodController2 : MonoBehaviour {
	public float speed;
	public float acceleration;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime/5, 0, 0);
		if (speed == maxSpeed) {
			acceleration = -acceleration;
			speed += acceleration;
		} else if (speed == -maxSpeed) {
			acceleration = -acceleration;
			speed += acceleration;
		} else {
			speed += acceleration;
		}
	}
}
