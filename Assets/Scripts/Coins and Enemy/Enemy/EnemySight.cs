using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	[SerializeField] 
	private Enemy enemy;

	void OnTriiggerEnter2D(Collider2D other){
		Debug.Log ("Enemy has see something");
		if (other.gameObject.tag == "Player") {
			enemy.target = other.gameObject;
		}
	}


	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			enemy.target = null;
		}
	}
}
