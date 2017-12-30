using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponents : MonoBehaviour {

	public Camera _camera;
	PlatfSelect currPS;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {


		Ray ray = _camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit) && hit.collider.gameObject.tag == "Platf") {
			
			PlatfSelect ps = hit.collider.gameObject.GetComponent<PlatfSelect> ();

			bool isMouseDown = Input.GetMouseButtonDown (0);
			bool isMouseUp = Input.GetMouseButtonUp (0);

			if (isMouseDown || isMouseUp) {
				
				if (isMouseDown) {
					ps.MouseDown ();
				} else {
					ps.MouseUp ();
				}
				
			} else {
				if (currPS != null)
					currPS.MouseLeave ();

				ps.MouseEnter ();
				currPS = ps;
			}

		} else {
			if (currPS != null)
				currPS.MouseLeave ();
			
			currPS = null;
		}


		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}
}
