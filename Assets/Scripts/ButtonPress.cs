using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

	public IEnumerator playSound(AudioSource sound){
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}
	public void printStuff(string stuff){
		print (stuff);
	}
}
