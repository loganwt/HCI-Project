using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour {
	public Text TopScoreText;
	// Use this for initialization
	void Start () {
		TopScoreText.text = "HiScore: " + PlayerPrefs.GetInt ("HiScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
