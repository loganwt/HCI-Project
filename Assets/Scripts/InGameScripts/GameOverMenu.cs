using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour {
	void Start () {
		//this.gameObject.SetActive (false);
		
	}

	public void ReturntoMenu (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void PlayAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
