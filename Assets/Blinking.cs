using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour {

	public float blinkingtime = 0.1f;
	float startingTime;
	// Use this for initialization
	void Start () {
		startingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startingTime >= blinkingtime) {
			if (gameObject.activeSelf) {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
			}
			startingTime = Time.time;
		}
	}
}
