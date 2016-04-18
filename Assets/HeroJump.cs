using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.Events;

public class HeroJump : MonoBehaviour {

	public bool isClickBool = false;

	// Use this for initialization
	void Start () {
		GameObject btnObject = GameObject.Find ("JumpBtn");
		Button btn = btnObject.GetComponent<Button> ();
		btn.onClick.AddListener(delegate(){
			this.OnClick();
		});
	}

	public void OnClick() {
		isClickBool = !isClickBool;
		Debug.Log ("+++call OnClick!!" + isClickBool);
	}


}
