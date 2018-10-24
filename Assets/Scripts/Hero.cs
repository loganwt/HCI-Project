using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	public float boostPower = 210f;
	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator animation;


	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		animation = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false) {

			if (Input.GetMouseButtonDown (0)) {

				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, boostPower));
				animation.SetTrigger ("Boost");

			}
		}
		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
	
		rb2d.velocity = Vector2.zero;
		animation.SetTrigger ("Die");
		isDead = true;
		GameControl.instance.HeroDied();
	}
}
