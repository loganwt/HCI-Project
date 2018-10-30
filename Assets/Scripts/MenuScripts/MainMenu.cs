using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

	public Text HiScoreText;

	void Start () {

		HiScoreText.text = "Current HiScore: " + PlayerPrefs.GetInt ("HiScore").ToString ();

	}

	public void PlayGame (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame (){
		Application.Quit ();
	}


	//Debug Button



	public void DebugButton (){
		PlayerPrefs.SetInt ("Total Coins", 0);
		PlayerPrefs.SetInt ("CanEquipBear", 0);
		PlayerPrefs.SetInt ("CanEquipMoney", 0);
		PlayerPrefs.SetInt ("EquippedSkin", 0);
		PlayerPrefs.SetInt ("HiScore", 0);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}
