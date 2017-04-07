using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private Scene currentScene;
	public void LoadLevel(string name)
	{
		Debug.Log ("Load Level Requested: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{	
		Debug.Log ("Quit Requested");
		Application.Quit ();
	}

	public void LoadNextLevel() 
	{
		currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentScene.buildIndex + 1);

	}

}
 