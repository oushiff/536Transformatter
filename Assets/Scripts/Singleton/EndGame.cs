using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		Debug.LogError ("hit the bottom");

		Application.LoadLevel (Application.loadedLevel);
		GameManager.Instance.RestartGame ();
	}
}
