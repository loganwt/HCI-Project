using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float timeAlive;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeAlive);
	}

}
