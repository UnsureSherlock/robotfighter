using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ButtonMapper : MonoBehaviour {
	/*
	 * ButtonMapper returns information about 
	 * what the action is mapped to what button
	 * also handles saving back into the config file
	 */

	JSONNode json_obj;

	private string txtfile = "button_config";

	public ButtonMapper(){
		
	}

	// Use this for initialization
	void Start () {
		TextAsset txtAssets = (TextAsset)Resources.Load (txtfile);
		this.json_obj = JSON.Parse (txtAssets.text);
	}

	JSONNode get_json(){
		return json_obj;
	}

	string get_left(){
		return json_obj["left"];
	}

	string get_right(){
		return json_obj["right"];
	}

	string get_up(){
		return json_obj["up"];
	}

	string get_down(){
		return json_obj["down"];
	}

	string get_attack1(){
		return json_obj["attack1"];
	}

	string get_attack2(){
		return json_obj["attack2"];
	}

	string get_attack3(){
		return json_obj["attack3"];
	}

	string get_attack4(){
		return json_obj["attack4"];
	}

	string get_block(){
		return json_obj["block"];
	}

	void save_config(JSONNode new_json){
		return;
		// TODO: saving the json object back into buttonmap
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
