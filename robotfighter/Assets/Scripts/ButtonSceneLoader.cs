using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonSceneLoader : MonoBehaviour {

	public string sceneToChange;

	public void sceneChange() {
		SceneManager.LoadScene(sceneToChange);
	}

	//https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
	//http://answers.unity3d.com/questions/855569/changing-scene-when-button-tapped.html
}
