using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hero : MonoBehaviour {

	public float boostPower = 210f;
    public AudioSource audioSource;
    //public AudioClip deathSound;
    private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator animation;


	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		animation = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource> ();
        //deathSound = GetComponent<AudioClip>();

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

        if (isDead == false)
        {
            rb2d.velocity = Vector2.zero;
            animation.SetTrigger("Die");
            audioSource.Play();
            isDead = true;
            GameControl.instance.HeroDied();
        }
	}




		
}