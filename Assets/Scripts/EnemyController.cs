using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float healPoints, damage, speed; 
	public AudioClip hitSoundEffect;
	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (healPoints <= 0) {
			Destroy (gameObject);
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ().killedMonster++;
		}
	}

	void FixedUpdate () {

		Vector3 movement = new Vector3 (-speed, 0.0f, 0.0f);
		rigid.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bullet") {
			healPoints--;
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<AudioSource> ().PlayOneShot (hitSoundEffect,1);
		} else if (coll.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ().isGameOver = true;
		}
	}
		
}
