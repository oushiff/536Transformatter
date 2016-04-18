using UnityEngine;
using System.Collections;

public class circleWithGapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			GameManager.Instance.RestartGame ();
		//else currentState.OnTriggerEnter(other);
	}
}
