using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightScore : MonoBehaviour {
	public static int Score = 0;
	Text RScore;
	// Use this for initialization
	void Start () {
		RScore = GetComponent<Text>();
	}
	
	// Update is called once per frame
		void Update () {
		RScore.text = Score.ToString(); 
	}
}
