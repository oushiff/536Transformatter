using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.Events;

public class HeroTransform : MonoBehaviour {

	public bool isSnowTransform = false;
	public bool isCloudTransform = false;
	public bool isCameraChange = false;

	// Use this for initialization
	void Start () {

		GameObject btnObject = GameObject.Find ("TransformBtn");
		Button btn = btnObject.GetComponent<Button> ();
		btn.onClick.AddListener(delegate(){
			this.OnClick();
		});
	}

	public void OnClick() {
		isSnowTransform = !isSnowTransform;
		isCloudTransform = !isCloudTransform;
		Debug.Log ("+++snow OnClick!!" + isSnowTransform);
		Debug.Log ("+++cloud OnClick!!" + isCloudTransform);

		isCameraChange = !isCameraChange;

	}


}
