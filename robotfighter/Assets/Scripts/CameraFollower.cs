using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public Transform ent1;
	public Transform ent2;

	private float dampTime = 0.5f;
	private float lowerLimit = -4f;
	private float startsize;
	private Vector3 velocity = Vector3.zero;
	private Camera thiscam;

	private Vector3 midpoint;

	// Use this for initialization
	void Start () {
		thiscam = GetComponent<Camera> ();
		startsize = thiscam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (ent1 != null && ent2 != null) {
			// find mid point then lerp to there and size camera

			midpoint = ((ent1.position - ent2.position)/2f) + ent2.position; // finds position between two

			Vector3 point = thiscam.WorldToViewportPoint(midpoint);
			Vector3 delta = midpoint - thiscam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
			Vector3 destination = transform.position + delta;

			if (destination.y < lowerLimit) {
				destination.y = lowerLimit;
			}
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);


			if (thiscam.orthographic)
			{
				// The camera's forward vector is irrelevant, only this size will matter
				if (midpoint.x > startsize) {
					thiscam.orthographicSize = midpoint.x;
				} else if (midpoint.x < -startsize) {
					thiscam.orthographicSize = -midpoint.x;
				} else {
					thiscam.orthographicSize = startsize;
				}
			}
			
		} else if (ent1 != null) {
			//lerp to ent1 
			Vector3 point = thiscam.WorldToViewportPoint(ent1.position);
			Vector3 delta = ent1.position - thiscam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
			Vector3 destination = transform.position + delta;

			if (destination.y < lowerLimit) {
				destination.y = lowerLimit;
			}
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);


			
		} else if (ent2 != null) {
			// lerp to ent2
			Vector3 point = thiscam.WorldToViewportPoint(ent2.position);
			Vector3 delta = ent2.position - thiscam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;

			if (destination.y < lowerLimit) {
				destination.y = lowerLimit;
			}
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		
		} else {
			// nothing to focus on
		}




		
	}
}
