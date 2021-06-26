using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftScore : MonoBehaviour {
	public static int Score =  0 ;
	Text LScore;

	// Use this for initialization
	void Start () {
		LScore = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		LScore.text = Score.ToString(); 
	}
}
