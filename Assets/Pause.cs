using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour {
	public Text pauseText;
	private bool paused;
	// Use this for initialization
	void Start () {
		paused = false;
		GetComponent<Button> ().onClick.AddListener (TogglePause);
	}

	void Update () {
		if (GameControl.instance.gameOver == true) {
			this.gameObject.SetActive (false);
		}
	}

	public void TogglePause(){
		Time.timeScale = Mathf.Approximately (Time.timeScale, 0.0f) ? 1.0f : 0.0f;
		if (paused == false) {
			pauseText.text = "UnPause";
			paused = true;
		}
		else{
			pauseText.text = "Pause";
			paused = false;
		}


	}
}
