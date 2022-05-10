using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	PlayerController control;
	BoxCollider boxcol;
	Animator anim;
	AudioSource AS;
	public static bool dead;
	public GameObject deadCam;

	public AudioClip dieSound;
	public AudioClip winSound;

	public GameObject ResultMenu;
	public GameObject WinMenu;

	void Start () {
		dead = false;
		control = GetComponent<PlayerController>();
		boxcol = GetComponent<BoxCollider>();
		anim = GetComponent<Animator>();
		AS = GetComponent<AudioSource>();
	}

	void Update () {
		if (transform.position.y < -0.5f && !dead) {
			boxcol.enabled = false;
			dead=true;
			AS.PlayOneShot(dieSound);
		}

		if (dead) {
			
			
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.CompareTag("Obstacle")) {
			dead=true;
			anim.SetTrigger("die");
			AS.PlayOneShot(dieSound);
			transform.parent = null;
			//dead
			ResultMenu.SetActive(true);
			control.enabled = false;
			deadCam.transform.parent = null;
		}
		else if (col.gameObject.CompareTag("Enemy"))
		{
			dead = true;
			transform.parent = null;
			AS.PlayOneShot(winSound);
			anim.SetTrigger("win");
			//win
			WinMenu.SetActive(true);
			control.enabled = false;
			deadCam.transform.parent = null;
		}
	}

}
