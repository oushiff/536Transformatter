using UnityEngine;
using System.Collections;

public class ResetTimeCoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.NumCoins = 0;
        GameManager.Instance.TimeRemaining = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
