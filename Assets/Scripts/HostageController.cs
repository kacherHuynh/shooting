using UnityEngine;
using System.Collections;

public class HostageController : MonoBehaviour {

	Animator animator;
	public Rigidbody2D rigid;
	public float speed = 1.0f;
	public ParticleSystem jetpack;
	public AudioClip hitEnemySoundEffect;

	// Use this for initialization

	void Awake(){
		animator = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
//		rigid.gravityScale = 15.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigid.velocity = new Vector3 (-speed, 0.0f, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground") {
			animator.SetBool ("isGrounded", true);
			speed = speed * 4;
			jetpack.enableEmission = false;
		} else if (coll.gameObject.tag == "bullet") {
			Destroy (gameObject);
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<AudioSource> ().PlayOneShot (hitEnemySoundEffect, 1);
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ().isGameOver = true;
		} else if (coll.gameObject.tag == "enemy") {
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ().isGameOver = true;
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<AudioSource> ().PlayOneShot (hitEnemySoundEffect, 1);

		}
	}
}
