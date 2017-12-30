using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawnObj;
	public float spawnTime = 1f;

	private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer <= 0) {
			Instantiate (spawnObj, transform.position, transform.rotation);

			timer = spawnTime;
		}

	}
}
