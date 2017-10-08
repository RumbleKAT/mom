using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoControl : MonoBehaviour {

	public int NextSequence;

	public GameObject CurrentObject;
	public GameTime currentSquence;
	public string pitch; 
	public bool move;
	public string Target_pitch;
	public int duration; 
	public float speed; 


	private Vector3 _location;

	// Use this for initialization
	void Start () {

		NextSequence = 0; 
		currentSquence = CurrentObject.GetComponent<GameTime> ();
		pitch = "";
		move = false; 
	}
	
	// Update is called once per frame
	void Update () {
		KeyInput ();
		MoveCheck ();
	}

	void PositionCheck(){
		float temp = transform.position.y;
		temp = ( Mathf.Round(temp/.1f)*.1f);
		transform.position = new Vector3 (transform.position.x, temp, transform.position.z);
	}

	void PitchCheck(){
		
		if (Target_pitch == pitch) {
			_location = transform.position; 

			move = true;
		} 

		else {
			move = false;
			Debug.Log ("Wrong Key!");
		}

	}

	void MoveCheck (){

		if (move) {
			//restore now location and compare future location
			MovePiano (_location);
		} else {
			PositionCheck ();
		}
	}

	void MovePiano(Vector3 _location){
		if (transform.position.y >= _location.y + duration - 0.2f) {
			move = false;
		} 
		else {
			transform.Translate (Vector3.up * Time.deltaTime * speed); 
		}
	}


	void KeyInput(){
		//Key press input

		/* White Key Input */ 
		if (Input.GetKeyDown (KeyCode.A)) {
			pitch = "4C";

		} // Do 
		else if (Input.GetKeyDown (KeyCode.S)) {
			pitch = "4D";

		} // Re
		else if (Input.GetKeyDown (KeyCode.D)) {
			pitch = "4E";

		} // Me 
		else if (Input.GetKeyDown (KeyCode.F)) {
			pitch = "4F";

		} // Fa 
		else if (Input.GetKeyDown (KeyCode.G)) {
			pitch = "4G";

		} // Sol 
		else if (Input.GetKeyDown (KeyCode.H)) {
			pitch = "4A";

		} // Ra
		else if (Input.GetKeyDown (KeyCode.J)) {
			pitch = "4B";

		} // Si

		/* Black Key Input */ 
		else if (Input.GetKeyDown (KeyCode.Q)) {
			pitch = "4C#";

		} // Do# 
		else if (Input.GetKeyDown (KeyCode.W)) {
			pitch = "4D#";

		} // Re#
		else if (Input.GetKeyDown (KeyCode.E)) {
			pitch = "4F#";

		} // Fa# 
		else if (Input.GetKeyDown (KeyCode.R)) {
			pitch = "4G#";

		} // Sol# 
		else if (Input.GetKeyDown (KeyCode.T)) {
			pitch = "4A#";

		} // Ra# 


		if (pitch != "") {
			PitchCheck ();
		}
	}
}
