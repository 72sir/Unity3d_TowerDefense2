using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfSelect : MonoBehaviour {

	public GameObject tower;

	public Material[] mat;
	bool isCanBuild = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MouseDown() {
		if (isCanBuild) {
			
			isCanBuild = false;
			Instantiate (tower, transform.position, transform.rotation);
			GetComponent<Renderer> ().material.color = mat[1].color;
		}
	}

	public void MouseUp() {
		Debug.Log ("MouseUp");

	}

	public void MouseEnter() {
		if (isCanBuild)
		GetComponent<Renderer> ().material.color = mat[0].color;
	}

	public void MouseLeave() {
		if (isCanBuild)
		GetComponent<Renderer> ().material.color = mat[1].color;
	}

}
