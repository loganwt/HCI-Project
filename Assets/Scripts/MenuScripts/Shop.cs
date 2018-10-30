using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
	//debug vairables. delete after done.
	public Text equipped;
	public Text canequipbear;


	//end of debug

	//Text variables
	public Text CoinTotalText;
	public Text BearText;
	public Text BearEquipText;
	public Text MoneyText;
	public Text MoneyEquipText;
	public Text AlienEquipText;

	//String Variables for buttons
	public string NotEnough = "Not Enough Coins!";
	public string Buy = "Buy";
	public string Equip = "Use";
	public string CurrentlyUsing = "Currently Using!";

	//Buttons
	//public GameObject alienButton;
	public GameObject equipAlienButton;
	public GameObject bearButton;
	public GameObject equipBearButton;
	public GameObject moneyButton;
	public GameObject equipMoneyButton;


	private int currentTotalCoins;
	private int canEquipBear;
	private int canEquipMoney;
	public int priceBear = 5;
	public int priceMoney = 10;
	private int equippedSkin;

	// Use this for initialization

	void Awake () {
		equippedSkin = PlayerPrefs.GetInt ("EquippedSkin");





	}

	void Start () {
		//Debug Code

		/**PlayerPrefs.SetInt ("Total Coins", 10);
		PlayerPrefs.SetInt ("CanEquipBear", 0);
		PlayerPrefs.SetInt ("CanEquipMoney", 0);**/

		canequipbear.text = "Can Equip " + PlayerPrefs.GetInt("CanEquipBear").ToString();
		equipped.text = "skin: " + PlayerPrefs.GetInt ("EquippedSkin").ToString ();

		//End of Debug Code

		PlayerPrefs.SetString ("Bear", NotEnough);
		PlayerPrefs.SetString ("Money", NotEnough);
		PlayerPrefs.SetString ("Alien", Equip);

		AlienEquipText.text = PlayerPrefs.GetString ("Alien");
		BearEquipText.text = PlayerPrefs.GetString ("Bear");
		MoneyEquipText.text = PlayerPrefs.GetString ("Money");




		canEquipBear = PlayerPrefs.GetInt ("CanEquipBear");
		canEquipMoney = PlayerPrefs.GetInt ("CanEquipMoney");

		//Grabs Player Prefs for Text
		AlienEquipText.text = PlayerPrefs.GetString ("Alien");
		BearText.text = PlayerPrefs.GetString("Bear");
		BearEquipText.text = PlayerPrefs.GetString ("Bear");
		MoneyText.text = PlayerPrefs.GetString("Money");
		MoneyEquipText.text = PlayerPrefs.GetString ("Money");

		CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
		currentTotalCoins = PlayerPrefs.GetInt ("Total Coins");
		bearButton.GetComponent<Button> ().interactable = false;

		//Checks to see if item can be afforded.

		if (currentTotalCoins >= priceBear && canEquipBear != 1) {
			bearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Bear", Buy);
			BearText.text = PlayerPrefs.GetString("Bear");
		}


		if (currentTotalCoins >= priceMoney && canEquipMoney != 1) {
			bearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Alien", Buy);
			BearText.text = PlayerPrefs.GetString("Bear");
		}

		if (canEquipBear == 1) {
			bearButton.SetActive (false);
			equipBearButton.SetActive (true);

		}


		if (canEquipMoney == 1) {
			moneyButton.SetActive (false);
			equipMoneyButton.SetActive (true);
		}




	}

	void Update () {

		equippedSkin = PlayerPrefs.GetInt ("EquippedSkin");

		if (currentTotalCoins < priceBear) {
			bearButton.GetComponent<Button> ().interactable = false;

		}

		if (currentTotalCoins < priceMoney) {
			moneyButton.GetComponent<Button> ().interactable = false;

		}
			
		//Checks to see which skin is equipped.
		switch (equippedSkin) {

		case 0:
			PlayerPrefs.SetString ("Alien", CurrentlyUsing);
			equipAlienButton.GetComponent<Button> ().interactable = false;
			equipBearButton.GetComponent<Button> ().interactable = true;
			equipMoneyButton.GetComponent<Button> ().interactable = true;

			PlayerPrefs.SetString ("Alien", CurrentlyUsing); 
			if (canEquipBear == 1) {
				PlayerPrefs.SetString ("Bear", Equip);
			} else {
				PlayerPrefs.SetString ("Bear", NotEnough);
			}

			if (canEquipMoney == 1) {
				PlayerPrefs.SetString ("Money", Equip);
			} else {
				PlayerPrefs.SetString ("Money", NotEnough);
			}



			break;

		case 1:
			PlayerPrefs.SetString ("Bear", CurrentlyUsing);
			PlayerPrefs.SetString ("Alien", Equip);
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");

			if (canEquipMoney == 1) {
				PlayerPrefs.SetString ("Money", Equip);
			} else {
				PlayerPrefs.SetString ("Money", NotEnough);
			}
			equipBearButton.GetComponent<Button> ().interactable = false;
			equipAlienButton.GetComponent<Button> ().interactable = true;
			equipMoneyButton.GetComponent<Button> ().interactable = true;
			break;

		case 2:
			
			PlayerPrefs.SetString ("Alien", Equip);

			if (canEquipBear == 1) {
				PlayerPrefs.SetString ("Bear", Equip);
			} else {
				PlayerPrefs.SetString ("Bear", NotEnough);
			}


			PlayerPrefs.SetString ("Money", CurrentlyUsing);
			equipAlienButton.GetComponent<Button> ().interactable = true;
			equipBearButton.GetComponent<Button> ().interactable = true;
			equipMoneyButton.GetComponent<Button> ().interactable = false;

			break;
		}




		if (currentTotalCoins >= priceBear && canEquipBear != 1) {
			bearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Bear", Buy);
			BearText.text = PlayerPrefs.GetString("Bear");
		}

		if (currentTotalCoins >= priceMoney && canEquipMoney != 1) {
			bearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Money", Buy);
			BearText.text = PlayerPrefs.GetString("Bear");
		}

			//canEquipBear = PlayerPrefs.GetInt ("CanEquipBear");
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			MoneyEquipText.text = PlayerPrefs.GetString ("Money");
			CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
			BearText.text = PlayerPrefs.GetString ("Bear");
			MoneyText.text = PlayerPrefs.GetString ("Money");

	
	}

	//Code for alien skin.
	public void EquipAlienItem (){
			PlayerPrefs.SetInt ("EquippedSkin", 0);



	}
	//Code for bear skin.
	public void BuyBearItem (){
			currentTotalCoins = currentTotalCoins - priceBear;
			PlayerPrefs.SetInt ("Total Coins", currentTotalCoins);
			CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
			PlayerPrefs.SetString ("Bear", Equip);
			BearEquipText.text = PlayerPrefs.GetString ("Bear"); 
			PlayerPrefs.SetInt("CanEquipBear", 1);
			canEquipBear = PlayerPrefs.GetInt("CanEquipBear");


	}

	public void EquipBearItem (){

			PlayerPrefs.SetInt ("EquippedSkin", 1);



	}
	//End of code for bear.

	//Code for money skin.
	public void EquipMoneyItem (){
		PlayerPrefs.SetInt ("EquippedSkin", 2);
	}

	public void BuyMoneyItem (){
		currentTotalCoins = currentTotalCoins - priceMoney;
		PlayerPrefs.SetInt ("Total Coins", currentTotalCoins);
		CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
		PlayerPrefs.SetString ("Money", Equip);
		MoneyEquipText.text = PlayerPrefs.GetString ("Money"); 
		PlayerPrefs.SetInt("CanEquipMoney", 1);
		canEquipMoney = PlayerPrefs.GetInt("CanEquipMoney");


	}

	//Debug Button

	public void DebugButton (){
		PlayerPrefs.SetInt ("Total Coins", 0);
		PlayerPrefs.SetInt ("CanEquipBear", 0);
		PlayerPrefs.SetInt ("CanEquipMoney", 0);
		PlayerPrefs.SetInt ("EquippedSkin", 0);
		PlayerPrefs.SetInt ("HiScore", 0);
	
	}


}
