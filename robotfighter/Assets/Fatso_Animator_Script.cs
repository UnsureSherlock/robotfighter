using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatso_Animator_Script : MonoBehaviour {

	private Animator animator;
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool ("walking", true);

			
		} else {
			animator.SetBool ("walking", false);
		}
		Debug.Log (animator.GetBool("walking"));
		
	}
}
