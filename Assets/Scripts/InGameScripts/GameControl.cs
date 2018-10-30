using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject GameOverText;
	public GameObject columnPrefab;
	public GameObject HeroAlien;
	public GameObject HeroBear;
	public GameObject HeroMoney;
	public GameObject GameOverMenu;
	public Text ScoreText;
	public Text CoinText;
	public Text HighScoreText;
	public Text TotalCoinText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;
	private int score = 0;
	private int coins = 0;
	private int currentHiScore = 0;
	private int currentTotalCoins = 0;
	private int equippedSkin;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		//Decides which hero will be used.

		equippedSkin = PlayerPrefs.GetInt ("EquippedSkin");


		switch (equippedSkin) {

		case 0:
			HeroAlien.SetActive (true);
			break;
		case 1:
			HeroBear.SetActive (true);
			break;
		case 2:
			HeroMoney.SetActive (true);
			break;
		}


	}

	// Use this for initialization
	void Start () {

		/**float y = Random.Range (-0.5f, 3f);
		float x = 6.15f;
		Vector2 columnSpawn = new Vector2 (x,y);
		Instantiate (columnPrefab, columnSpawn, Quaternion.identity);**/

		TotalCoinText.text = "Total Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
		HighScoreText.text = "HiScore: " + PlayerPrefs.GetInt ("HiScore").ToString();
		currentHiScore = PlayerPrefs.GetInt ("HiScore");
		currentTotalCoins = PlayerPrefs.GetInt ("Total Coins");



	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void HeroGotCoin(){
		if (gameOver == true) {
			return;
		}
		currentTotalCoins++;
		PlayerPrefs.SetInt ("Total Coins", currentTotalCoins);

		coins++;
		score++;
		TotalCoinText.text = "Total Coins: " + currentTotalCoins.ToString ();
		ScoreText.text = "Score: " + score.ToString ();
		CoinText.text = "x " + coins.ToString ();
	}

	public void HeroScored(){

		if (gameOver == true) {
			return;
		}

		score++;
		ScoreText.text = "Score: " + score.ToString ();
	}

	public void HeroDied(){
		StartCoroutine(DelayGameOver());
		gameOver = true;
		if (score > currentHiScore) {
			PlayerPrefs.SetInt ("HiScore", score);
		}

	}

	IEnumerator DelayGameOver(){

		yield return new WaitForSeconds(0.5f);

		GameOverMenu.SetActive(true);
	}
}
