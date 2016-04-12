using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Canvas quitMenu;
	public Canvas levelMenu;
	public Button startText;
	public Button exitText;


	void Start ()

	{
		//quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		levelMenu = levelMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		levelMenu.enabled = false;

	}

	public void ExitPress() //this function will be used on our Exit button

	{
		//quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
		startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;
		levelMenu.enabled = false;

	}

	public void NoPress() //this function will be used for our "NO" button in our Quit Menu

	{
		//quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;
		levelMenu.enabled = false;

	}

	public void StartLevelMenu () //this function will be used on our Play butt
	{

		levelMenu.enabled = true;

		//this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu

	{
		Application.Quit(); //
	}

	public void Startlevel1()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void StartLevel2()
	{
		SceneManager.LoadScene ("Level2");
	}

	public void StartLevel3()
	{
		
		SceneManager.LoadScene ("Level3");
	
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene ("StartPage");
	}

}
