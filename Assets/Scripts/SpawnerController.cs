using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	public Transform minY, maxY;
	public int maxOfEnemy = 3;
	public Object enemyPrefab;

	float previousSpeed,previousY = 0.0f;
	float currentY,currentSpeed;
	float waitingTime = 2, startingTime;
	// Use this for initialization
	void Start () {
		startingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startingTime >= waitingTime)
			Spawn ();
	}

	int numOfCurrentEnemy(){
		int num;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		num = enemies.Length;
		return num;
	}

	void Spawn(){
		// check if we need to spawn new enemy
		if (numOfCurrentEnemy () >= maxOfEnemy)
			return;
		GameObject go = GameObject.Instantiate (enemyPrefab) as GameObject;

		currentSpeed = RandomSpeed ();

		while (currentSpeed == previousSpeed) {
			currentSpeed = RandomSpeed ();
		}

		currentY = Random.Range (minY.position.y, maxY.position.y);

		if (previousY != 0) {
			while (Mathf.Abs (currentY - previousY) <= 2 ) {
				currentY = Random.Range (minY.position.y, maxY.position.y);
			}
		}

		go.GetComponent<EnemyController> ().speed = currentSpeed;
		go.transform.position = new Vector2 (minY.position.x, currentY);
		go.GetComponent<EnemyController> ().healPoints = Random.Range (1,4);
		previousY = currentY;
		previousSpeed = currentSpeed;
	}

	int RandomSpeed(){
		
		int speed = Random.Range (3,5);
		return speed;
	}
}
