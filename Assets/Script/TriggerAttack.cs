using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour {

	// GameObject tower;
	public GameObject towerHead;
	public GameObject bullet;
	public float TimeShoot = 1f;

	bool find = false;
	GameObject curEnemy = null;
	float timerShoot = 0f;


	void Update() {
		if (!curEnemy) {
			find = false;
			curEnemy = null;
		}
	}

	void OnTriggerStay(Collider other) {

		if (other.CompareTag("Enemy")) {
			if (!find && !curEnemy) {
				towerHead.transform.LookAt (other.transform);
				curEnemy = other.gameObject;
				find = true;
			} else {
				//bullet.GetComponent<Bullet> ().Enemy = curEnemy;
				if (curEnemy) {
					Shoot ();
					towerHead.transform.LookAt (curEnemy.transform);
				}
				else {
					curEnemy = null;
					find = false;
				}
			}
		}
	}


	void OnTriggerExit(Collider other) {
		if (find && curEnemy == other.gameObject) {
			find = false;
			curEnemy = null;
		} 
	}


	private void Shoot() {
		timerShoot -= Time.deltaTime;

		if (timerShoot <= 0) {
			timerShoot = TimeShoot;
			GameObject obj = (GameObject)Instantiate (bullet, towerHead.transform.position, towerHead.transform.rotation);
			Bullet b = obj.GetComponent<Bullet> ();
			b.Enemy = curEnemy.gameObject;
		}
	}


}
