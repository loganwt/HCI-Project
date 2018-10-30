using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour {

	public float lastSpawn = 0f;
	public float cooldown = 2f;
	public float coinMin = -0.5f;
	public float coinMax = 2f;
	private float startTime;
	private float elapsedTime;
	public float spawnXposition = 2.5f;
	public GameObject coinPrefab;

	void Start ()
	{
		startTime = Time.time;

	}

	void Update ()
	{
		elapsedTime = Time.time - startTime;
			float spawnYposition = Random.Range (coinMin, coinMax);
			Vector2 spawnPoint = new Vector2 (spawnXposition, spawnYposition);
		if (elapsedTime >= lastSpawn + cooldown && GameControl.instance.gameOver == false) {
				Instantiate (coinPrefab, spawnPoint, Quaternion.identity);
				lastSpawn = elapsedTime;
				
			}



	}



}
