using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class to set a timer during a fight and count down until the fight is over.
public class Timer : MonoBehaviour
{

	public Text TimerText;
	public int timeLeft = 180;
	private bool pPressed = false;

	void Start()
	{
		this.InvokeRepeating ("setTimeText", 0, 1);
	}

	void setTimeText()
	{
		if (timeLeft >= 0) {
			TimerText.text = "Time: " + timeLeft.ToString ();
			timeLeft = timeLeft - 1;
		}
		else if  (timeLeft < 0) {
			TimerText.text = "Times Up!";
		}
		/*
		if (Input.GetKeyDown("p") == true) {
			buttonPressed (pPressed);
			CancelInvoke ();	
		} else if (timeLeft < 0) {
			CancelInvoke ();
		}*/
	}

	/// <summary>
	/// For when a button is pressed like pause.
	/// </summary>
	void switchBool(bool name){
		if (name == false) {
			name = true;
		} else {
			name = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		//Cancel Invoke
		//if (Input.GetButton("")){
		 //else {
		//}
	}

	//http://answers.unity3d.com/questions/219281/making-text-boxes-with-letters-appearing-one-at-a.html

	//For when we want to pause https://docs.unity3d.com/ScriptReference/MonoBehaviour.CancelInvoke.html
	//https://docs.unity3d.com/ScriptReference/Time-timeScale.html
	//http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
}
