using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	private Transform target;

	// Use this for initialization
	void Start () {
		this.target = GameObject.Find ("SnowBall").transform;
	}

	// Update is called once per frame
	void Update () {
		Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);

		float cameraMovementX = 0.5f;
		float cameraMovementY = 0.5f;

		if ((target.position.x - 3f) < 0) {
			cameraMovementX = point.x;
		}

		if ((target.position.y - 2.8f) < 0) {
			cameraMovementY = point.y;
		}

		Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(cameraMovementX, cameraMovementY, point.z));
		Vector3 destination = transform.position + delta;
		this.transform.position = Vector3.SmoothDamp (this.transform.position, destination, ref velocity, dampTime);
	}
}