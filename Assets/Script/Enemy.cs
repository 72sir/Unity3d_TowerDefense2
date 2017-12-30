using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 2f;
	public float maxLife = 100f;
	private Transform wayPoints;
	private Transform wayPoint;
	private int wayPointIndex = -1;
	private float life;

	// Use this for initialization
	void Start () {
		wayPoints = GameObject.Find ("WayPoits").transform;
		NexWayPoint ();
		life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = wayPoint.transform.position - transform.position;
		dir.y = 0;

		float _speed = Time.deltaTime * speed;
		transform.Translate (dir.normalized * _speed);
		if (dir.magnitude <= _speed)
			NexWayPoint ();
		
	}

	void NexWayPoint() {
		wayPointIndex++;

		if (wayPointIndex >= wayPoints.childCount) {
			Destroy (gameObject);
			return;
		}

		wayPoint = wayPoints.GetChild (wayPointIndex);

	}

	public void SetDamage(float value) {
		life -= value;

		if (life <= 0)
			Destroy (gameObject);
	}
}
