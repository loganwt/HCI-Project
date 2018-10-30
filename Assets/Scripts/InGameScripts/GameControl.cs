using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


	public static GameControl instance;
	public GameObject columnPrefab;
	public GameObject HeroAlien;
	public GameObject HeroBear;
	public GameObject HeroMoney;
	public GameObject GameOverMenu;
	public GameObject ScoreCoins;
	public Text FinalCoinText;
	public Text FinalScoreText;
	public Text GameOverText;
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

	private bool paused = false;
	public Text pauseText;

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
		float y = Random.Range (-0.5f, 3f);
		float x = 9.5f;
		//float y2 = Random.Range (-0.5f, 3f);
		//float x2 = 10.5f;
		Vector2 columnSpawn = new Vector2 (x,y);
		//Vector2 columnSpawn2 = new Vector2 (x2,y2);
		Instantiate (columnPrefab, columnSpawn, Quaternion.identity);
		//Instantiate (columnPrefab, columnSpawn2, Quaternion.identity);


		TotalCoinText.text = "Total Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
		HighScoreText.text = "HiScore: " + PlayerPrefs.GetInt ("HiScore").ToString();
		currentHiScore = PlayerPrefs.GetInt ("HiScore");
		currentTotalCoins = PlayerPrefs.GetInt ("Total Coins");



	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver != false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Time.timeScale = Mathf.Approximately (Time.timeScale, 0.0f) ? 1.0f : 0.0f;
				if (paused == false) {
					pauseText.text = "Paused";
					paused = true;
				} else {
					pauseText.text = "";
					paused = false;
				}
			}
		}

		
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

		FinalCoinText.text = "Coins Collected: " + coins.ToString ();
		FinalScoreText.text = "Your Score: " + score.ToString ();
		TotalCoinText.text = "Total Coins: " + currentTotalCoins.ToString ();
		ScoreCoins.SetActive (false);

		if (score > currentHiScore) {
			PlayerPrefs.SetInt ("HiScore", score);
			HighScoreText.text = "NEW HISCORE: " + PlayerPrefs.GetInt("HiScore").ToString();
			HighScoreText.color = new Color (255, 237, 0, 255);
		} else {
			HighScoreText.text = "Current HiScore: " + PlayerPrefs.GetInt("HiScore").ToString();
		}

	}

	IEnumerator DelayGameOver(){

		yield return new WaitForSeconds(0.5f);

		GameOverMenu.SetActive(true);
	}
}
