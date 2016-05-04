using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManagerController : MonoBehaviour {

	// Use this for initialization
	public bool isGameOver = false; bool isResultShown = false;
	public Text scoreValue;
	public int killedMonster = 0;
	public int level;

	public List<int> hostageCheckPOints = new List<int>();
	public GameObject hostageSpawner;
	public GameObject enemySpawner;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			if (!isResultShown)
				StartCoroutine (GameOverAndShowResult ());
		} else {
			SpawnHostage ();
		}
	}

	public void UpdateScore(int score){
		scoreValue.text = score.ToString ();
	}

	public void ShowResult(){
		isResultShown = true;
		Time.timeScale = 0;

		//:TODO open prefabs for game result

	}

	IEnumerator GameOverAndShowResult(){
		yield return new WaitForSeconds (0.2f);
		ShowResult ();
	}

	void SpawnHostage(){
		// check score to spawn the hostage
		if (hostageCheckPOints.Contains (killedMonster)) {
			foreach (int i in hostageCheckPOints) {
				if (i == killedMonster) {
					hostageCheckPOints.Remove (i);
					break;
				}
			}
			hostageSpawner.GetComponent<HostageSpawnerController> ().Spawn ();

			// if player kill 2 monster we will increase the total monster 1. 
			if (hostageCheckPOints.Count % 2 == 0) {
				enemySpawner.GetComponent<SpawnerController> ().maxOfEnemy++;
			}
		}
	}

	public void ReloadLevel(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Main");
	}
}
