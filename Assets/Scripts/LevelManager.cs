using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit ();
	}


}
