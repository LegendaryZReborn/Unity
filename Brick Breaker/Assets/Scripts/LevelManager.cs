using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private Scene currentScene;

	public void LoadLevel(string name)
	{
		//Load level by name
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{	
		//Quit
		Application.Quit ();
	}

	public void LoadNextLevel() 
	{
		currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentScene.buildIndex + 1);

	}

}
 