using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	// Use this for initialization
	void Start () {
		//save the current level name
		currentLevel = Application.loadedLevelName;
	}

	// Update is called once per frame
	void Update () {
		//move the player based on left and right arrow keys
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0); //get input
	}

	//check if the player hits the Goal object
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name=="flag"){
			UnlockLevels();   //unlock next level funxtion 
		}
	}

	protected void  UnlockLevels (){
		//set the playerprefs value of next level to 1 to unlock
		//for(int i = 0; i < LockLevel.worlds; i++){
		for(int j = 0; j < LockLevel.levels; j++){               
			if(currentLevel == "Level"+(j+1).ToString()) {
				//worldIndex  = (i+1);
				levelIndex  = (j+1);
				PlayerPrefs.SetInt("level"+(levelIndex+1).ToString(),1);
			}

		}
		//load the World1 level 
		//Application.LoadLevel("StartPage");
		SceneManager.LoadScene("StartPage");	 
	}
}