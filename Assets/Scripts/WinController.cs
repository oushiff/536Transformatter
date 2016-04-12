using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		Debug.LogError ("hit the flag");
        GameManager.Instance.CoinsGot = GameManager.Instance.NumCoins;
        GameManager.Instance.TimeConsumed = GameManager.Instance.TimeRemaining;

        

		SceneManager.LoadScene ("WinPage");
	}
}
