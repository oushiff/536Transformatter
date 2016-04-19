using UnityEngine;
using System.Collections;

public class CircleIceController : MonoBehaviour {

	public HeroTransform heroTransform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Collision!!!");
		if (other.gameObject.tag == "PlayerCloud") {
			// health decrease
			heroTransform.OnClick ();
		}
		//GameManager.Instance.RestartGame ();
		//else currentState.OnTriggerEnter(other);
	}
}
