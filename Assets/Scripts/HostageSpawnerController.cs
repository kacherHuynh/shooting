using UnityEngine;
using System.Collections;

public class HostageSpawnerController : MonoBehaviour {

	public Transform minX, maxX;
	public Object hostagePrefab;
	GameManagerController gameManagerController;
	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){ 
		float x = Random.Range (minX.position.x, maxX.position.y);
		GameObject go = GameObject.Instantiate (hostagePrefab) as GameObject;
		go.transform.position = new Vector2 (x, minX.position.y);
		go.GetComponent<HostageController> ().rigid.gravityScale = Random.Range (15, 20);
		go.GetComponent<HostageController> ().speed = Random.Range (1, 4);
	}
}
