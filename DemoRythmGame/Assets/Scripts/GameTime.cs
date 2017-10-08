using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour {

	public GameObject Metronume;
	public GameObject MusicJson;

	private Metronume MetroData;
	private LoadData JsonData; //Loading NoteInfo 

	public int currentStep;
	public int currentMeasure; 
	public int EndMeasure;

	void Start(){
		SettingMetronume ();
	}

	// Update is called once per frame
	void Update () {
		LoadingMetronume ();
	}

	void SettingMetronume(){
		//setting Metronume data

		MetroData = Metronume.GetComponent<Metronume> ();
		JsonData = MusicJson.GetComponent<LoadData> ();

		MetroData.Base = JsonData.noteinfo.beats_type;
		MetroData.Step = JsonData.noteinfo.beats;
		MetroData.BPM = JsonData.noteinfo.tempo;

		EndMeasure = JsonData.notedatas [JsonData.notedatas.Length-1].measureIndex;
	}
		
	void LoadingMetronume(){
		//loading Metronume data real-time 

		currentStep = MetroData.CurrentStep; 	// need duration checking 
		currentMeasure = MetroData.CurrentMeasure; 

		if (currentMeasure >= EndMeasure + 1) {
			currentMeasure = 0; 
			currentStep = 0;
		}
	}
}
