using UnityEngine;
using System.Collections;

public class DestroyerController : MonoBehaviour {

	// Use this for initialization
	int score = 0;
	public GameObject gameManagerObject;

	void Start () {

	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "hostage") {
			Destroy (coll.gameObject);
			score++;
			gameManagerObject.GetComponent<GameManagerController> ().UpdateScore (score);
		} else if (coll.gameObject.tag == "enemy") {
			Destroy (coll.gameObject);
			gameManagerObject.GetComponent<GameManagerController> ().isGameOver = true;
		}
	}
}
