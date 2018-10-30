using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour {
	public Text CoinTotalText;
	// Use this for initialization
	void Start () {
		CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
	}

}
