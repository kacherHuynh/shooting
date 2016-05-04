using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	// Use this for initialization
	public float speed = 0.3f;
	Vector2 offset;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (Time.time * speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
