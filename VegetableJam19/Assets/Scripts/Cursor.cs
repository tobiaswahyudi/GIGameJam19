using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	private Camera cam;

	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10) ;
	}
}
