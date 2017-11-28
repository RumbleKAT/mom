﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteDetail : MonoBehaviour {

    public int default_x;
	public string pitch;
	public int duration;
	public int sequence; //measure
    public int note_index; //counting note
}
