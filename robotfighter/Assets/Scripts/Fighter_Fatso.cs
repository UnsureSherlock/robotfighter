using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter_Fatso : Fighter {
	
	private float speed = 40f;
	private float cSpeed;
	private float maxSpeed = 10f;
	private float jumpSpeed = 10f;

	private bool on_ground_bool = true;

	private bool invul = false;
	private float invul_timer = 2f;
	public SpriteRenderer playerSprite;
	private Rigidbody playerRb;

	// Use this for initialization
	void Start () {
		cSpeed = speed;
		invul = false;
		playerRb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (invul) {
			invul_timer -= Time.deltaTime;
			if (invul_timer < 0) {
				invul = false;
				invul_timer = 2f;
			}
		}
	}

	public void freeze(){

	}


	public void unfreeze(){

	}

	void FixedUpdate () {

		// Get Hor and Vert inputs
		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");


		// Adds speed to bot
		if (hor > 0) {
			playerRb.AddForce (new Vector2 (cSpeed, 0));
		} else if (hor < 0) {
			playerRb.AddForce (new Vector2 (-cSpeed, 0));
		} else {
			playerRb.velocity.Set (0, 0, 0);
		}

		if ( !((transform.eulerAngles.z < 16) || (transform.eulerAngles.z > 344)) ) {
			playerRb.AddForce (new Vector2 (cSpeed, 0));
		}

		// Handles MAX speed
		if (Mathf.Abs(playerRb.velocity.x) > maxSpeed) {
			playerRb.AddForce (new Vector2 (-hor * cSpeed, 0));
		}

		// Jumping of the Bot
		if ((vert > 0)&&(on_ground())) {
			playerRb.AddForce(new Vector2(0,jumpSpeed), ForceMode.Impulse);
			on_ground_bool = false;
		}

	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.transform.position.y < gameObject.transform.position.y) {
			if (col.gameObject.tag == "Ground") {
				on_ground_bool = true;
			}
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			on_ground_bool = false;
		}
	}

	override public float get_total_health (){
		return 100f;
	}

	override public bool on_ground (){
		return on_ground_bool;
	}
}
