using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour {

	[SerializeField]
	private Text question;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	[SerializeField]
	private Button cancelButton;

	[SerializeField]
	private GameObject modalPanelObject;
	 
	private static ModalPanel modalPanel;

	public static ModalPanel Instance(){
		if (!modalPanel) {
			modalPanel = FindObjectOfType (typeof(ModalPanel))as ModalPanel;
			if (!modalPanel) {
				Debug.LogError ("There needs to be one active Modal Panel script on a game object in your scene");
			}
		}
		return modalPanel;
	}

	//Yes, No, Cancel: A string, a Yes event, a No event, and a Cancel event
	public void Choice (string quesion, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent){
		modalPanelObject.SetActive (true);

		yesButton.onClick.RemoveAllListeners (); //This script has to be reused, first clear the former ones
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners (); //This script has to be reused, first clear the former ones
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener (ClosePanel);

		cancelButton.onClick.RemoveAllListeners (); //This script has to be reused, first clear the former ones
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener (ClosePanel);

		this.question.text =  question.ToString();

		this.iconImage.gameObject.SetActive (false);

		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);
		cancelButton.gameObject.SetActive (true);
	}

	void ClosePanel(){
		modalPanelObject.SetActive (false);
	}
}
