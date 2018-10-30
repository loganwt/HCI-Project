using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

	public float lastSpawn = 0f;
	public float cooldown = 2f;
	public float coinMin = -1.5f;
	public float coinMax = 3f;
	public float columnMin = -1.5f;
	public float columnMax = 3f;
	private float startTime;
	private float elapsedTime;
	public float spawncolumnXposition = 10f;
	//public float spawncoinXposition = 20f;
	public GameObject coinPrefab;
	public GameObject columnPrefab;

	void Start ()
	{
		startTime = Time.time;

	}

	void Update ()
	{
		elapsedTime = Time.time - startTime;
		float spawncolumnYposition = Random.Range (columnMin, columnMax);
		float spawncoinYposition = Random.Range (coinMin, coinMax);
		Vector2 spawnPointPipe = new Vector2 (spawncolumnXposition, spawncolumnYposition);
		Vector2 spawnPointCoin = new Vector2 (spawncolumnXposition + 2.75f, spawncoinYposition);
		if (elapsedTime >= lastSpawn + cooldown && GameControl.instance.gameOver == false) {
			int spawnCoin = Random.Range (1, 3);
			Instantiate (columnPrefab, spawnPointPipe, Quaternion.identity);
			lastSpawn = elapsedTime;
			if (spawnCoin == 2) {
				Instantiate (coinPrefab, spawnPointCoin, Quaternion.identity);
			}

		}



	}



}