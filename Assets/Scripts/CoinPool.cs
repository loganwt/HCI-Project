using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour {

	public int coinPoolSize = 5;
	public GameObject coinPrefab;
	public float spawnRate = 2f;
	public float coinMin = -0.5f;
	public float coinMax = 2f;

	private GameObject[] coin;
	private Vector2 objectPoolPosition = new Vector2 (-15, -25f);
	private float timeSinceLastSpawned; 
	private float spawnXPosition = 2f;
	private int currentCoin = 0;

	// Use this for initialization
	void Start () {
		coin = new GameObject[coinPoolSize];
		for (int i = 0; i < coinPoolSize; i++) {
			coin [i] = (GameObject)Instantiate (coinPrefab, objectPoolPosition, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYposition = Random.Range (coinMin, coinMax);
			coin [currentCoin].transform.position = new Vector2 (spawnXPosition, spawnYposition);
			currentCoin++;
			if (currentCoin >= coinPoolSize) {
				currentCoin = 0;
			}
		}
	}
	
}
