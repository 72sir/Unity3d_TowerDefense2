using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfSelect : MonoBehaviour {

	public GameObject tower;

	public Material[] mat;
	bool isCanBuild = true;

	public void MouseDown() {
		if (isCanBuild) {
			
			Instantiate (tower, transform.position, transform.rotation);
			GetComponent<Renderer> ().material.color = mat[1].color;

			isCanBuild = false;
		}
	}

	public void MouseUp() {

			GetComponent<Renderer> ().material.color = mat[0].color;

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
