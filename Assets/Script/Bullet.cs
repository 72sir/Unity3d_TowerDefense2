using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float Speed = 0.5f;
	public float TimeLife = 1f;
	public Enemy Enemy;
	public float damage = 25f;

	float timerLife;

	// Use this for initialization
	void Start () {
		timerLife = TimeLife;
	}
	
	// Update is called once per frame
	void Update () {
		timerLife -= Time.deltaTime;

		Vector3 dir = Enemy.transform.position - transform.position;
		float _speed = Speed * Time.deltaTime;

		if (timerLife <= 0) {
			
			timerLife = TimeLife;
			Destroy (gameObject);

		} else if (dir.magnitude <= _speed) {
			Enemy.SetDamage (damage);
			Destroy (gameObject);
			return;
		}

		transform.Translate (new Vector3(0, 0, _speed));
	}
}
