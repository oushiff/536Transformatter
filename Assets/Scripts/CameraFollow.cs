using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	public HeroTransform heroTransform;
	private bool isCloudCamera = false;

	void Awake(){
		isCloudCamera = false;
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("PlayerSnow");


	}

	void FixedUpdate()
	{

		bool isBtnClick = heroTransform.isCameraChange;

		if (isBtnClick) {
			heroTransform.isCameraChange = false;
			isBtnClick = false;
			isCloudCamera = !isCloudCamera;
			if (isCloudCamera) {
				Debug.Log ("Camera Follow Cloud!!!!");
				player = GameObject.FindGameObjectWithTag ("PlayerCloud");
			} else {
				Debug.Log ("Camera Follow Snow!!!!");
				player = GameObject.FindGameObjectWithTag ("PlayerSnow");
			}

		}


//		Debug.Log (transform == null, player == null);		
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY,transform.position.z);

		if (bounds)
		{
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp(transform.position.y,minCameraPos.y,maxCameraPos.y),
				Mathf.Clamp(transform.position.z,minCameraPos.z,maxCameraPos.z));
		
		}

	}


}
