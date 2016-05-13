using UnityEngine;
using System.Collections;

public class HostageSpawnerController : MonoBehaviour {

	public Transform minX, maxX;
	public Object hostagePrefab;
	GameManagerController gameManagerController;

	public Object warningPrefab;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){ 
		float x = Random.Range (minX.position.x, maxX.position.y);
		Vector2 position = new Vector2 (x, minX.position.y);
		SpawnWarning (position);
		StartCoroutine (SpawnHostage (position, 1.5f));
	}

	void SpawnWarning(Vector2 position){ 
		GameObject warningObj = GameObject.Instantiate (warningPrefab) as GameObject;
		warningObj.transform.position = new Vector2(position.x, position.y - 1.5f);
		Destroy (warningObj, 2f);
	}

	IEnumerator SpawnHostage(Vector2 postion, float delay){
		
		yield return new WaitForSeconds(delay);

		GameObject go = GameObject.Instantiate (hostagePrefab) as GameObject;
		go.transform.position = postion;
		go.GetComponent<HostageController> ().rigid.gravityScale = Random.Range (15, 20);
		go.GetComponent<HostageController> ().speed = Random.Range (1, 4);
	}
}
