using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public float FindRadius = 2f;
	public float TimeShoot = 1f;
	public GameObject bullet;


	Enemy enemy;
	Transform towerHead;
	float timerShoot = 0f;

	// Use this for initialization
	void Start () {
		towerHead = transform.Find ("TowerHead");
	}
	
	// Update is called once per frame
	void Update () {

		if (enemy == null) {
			// Ищем противника
			FindEnemy ();
		} else {
			// Поворот пушки в протиника и выстрел
			towerHead.LookAt(enemy.transform);

			Shoot ();

			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			if (dist > FindRadius)
				enemy = null;
		}
	}

	private void Shoot() {
		timerShoot -= Time.deltaTime;

		if (timerShoot <= 0) {
			timerShoot = TimeShoot;
			GameObject obj = (GameObject)Instantiate (bullet, towerHead.transform.position, towerHead.transform.rotation);
			Bullet b = obj.GetComponent<Bullet> ();
			b.Enemy = enemy;
		}
	}

	private void FindEnemy() {
		var enemies = GameObject.FindObjectsOfType<Enemy> ();
		float min = FindRadius;
		Enemy minEnemy = null;

		foreach (var e in enemies) {
			float dist = Vector3.Distance (e.transform.position, transform.position);

			if (dist <= min) {
				min = dist;
				minEnemy = e;
			}

		} 

		enemy = minEnemy;
	}
}
