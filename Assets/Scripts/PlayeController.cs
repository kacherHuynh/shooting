using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayeController : MonoBehaviour {

	public float speed = 10.0f;
	public float bulletSpeed = 20.0f;
	public Rigidbody2D rocket;
	public Transform shootingPos;

	public AudioClip shootingSound;

	Rigidbody2D rigid;
	void Start() {
		rigid = this.GetComponent<Rigidbody2D> ();
	}

	void Update (){ 
		
//		if (Input.GetButtonDown("Fire1")) {
//			Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
//			bulletInstance.velocity = new Vector2 (bulletSpeed, 0);
//		}
	}

	void FixedUpdate () {
		
		float moveVertical = CrossPlatformInputManager.GetAxis ("Vertical") * speed ;

		Debug.Log (moveVertical);

		if (moveVertical > 0) {
			transform.position = Vector3.up * speed * Time.deltaTime;
		} else {
//			destination = Vector3.down * moveVertical;
//			transform.position = Vector3.Lerp (transform.position, destination, Time.deltaTime);
		}

//		Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);
//		rigid.velocity = movement;




		if (CrossPlatformInputManager.GetButtonDown ("Shoot")) {
			Rigidbody2D bulletInstance = Instantiate (rocket, shootingPos.position, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (bulletSpeed, 0);
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<AudioSource> ().PlayOneShot (shootingSound,1);
		}
	}


}
