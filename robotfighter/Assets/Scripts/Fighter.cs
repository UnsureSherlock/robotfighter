using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour {
	
	public Fighter ()
	{
		// init code here
	}

	void Start(){
		// find controlls that belong to you and map them
	}

	void Update(){
		
	}

	abstract public float get_total_health ();

	//position checks
	abstract public bool on_ground ();
	public bool in_air ()
	{
		return !on_ground ();
	}

}

