using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalWindow : MonoBehaviour {
	private ModalPanel modalPanel;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;


	void Awake(){

		modalPanel = ModalPanel.Instance ();
		myYesAction = new UnityAction (TestYesFuncion);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);
	}

	public void TextYNC(){
		modalPanel.Choice ("Would you like a poke in the eye? \n How about with a sharp stick?"
									, myYesAction, myNoAction, myCancelAction);
		
	}

	//Send to the Modal Panel to set up the Buttions and Functions to call

	// There are wrapped into UnityActions

	void TestYesFuncion(){
		Debug.LogError ("Yes Button has been pressed");
	}

	void TestNoFunction(){
		Debug.LogError ("No Button has been pressed");
	}

	void TestCancelFunction(){
		Debug.LogError ("Cancel Button has been pressed");
	}
}
