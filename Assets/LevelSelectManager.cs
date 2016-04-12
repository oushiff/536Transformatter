using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelSelectManager : MonoBehaviour {

	private int worldIndex;   
	private int levelIndex;   

	void  Start (){
		//loop thorugh all the worlds
		//for(int i = 1; i <= LockLevel.worlds; i++){
		Scene activeScene = SceneManager.GetActiveScene();
		if(activeScene.name == "StartPage"){
			//if(Application.loadedLevelName == "StartPage"){
			//worldIndex = i;
			CheckLockedLevels(); 
		}
	}
	//}

	//Level to load on button click. Will be used for Level button click event 
	public void Selectlevel(string worldLevel){
		Application.LoadLevel("Level"+worldLevel); //load the level
	}

	//uncomment the below code if you have a main menu scene to navigate to it on clicking escape when in World1 scene
	/*public void  Update (){
  if (Input.GetKeyDown(KeyCode.Escape) ){
   Application.LoadLevel("MainMenu");
  }   
 }*/

	//function to check for the levels locked
	void  CheckLockedLevels (){
		//loop through the levels of a particular world
		for (int j = 0; j < LockLevel.levels; j++) {
			levelIndex = (j + 1);
			if (PlayerPrefs.HasKey("level" + levelIndex.ToString ())){
				int levelLock = (PlayerPrefs.GetInt ("level" + levelIndex.ToString ()));
				if (levelLock == 1) {
					GameObject lockedLevelObject = GameObject.Find ("LockedLevel" + levelIndex.ToString ());
					if (lockedLevelObject != null) {
						lockedLevelObject.active = false;
						Debug.Log ("Unlocked");
					}
				}
			}
		}
	}
}

