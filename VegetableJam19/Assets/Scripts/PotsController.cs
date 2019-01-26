using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotsController : MonoBehaviour {

	public Transform cursor;
	public int unlocked;
	public Transform[] squares;

	private CameraController CamCon;

	// Use this for initialization
	void Start () {
		CamCon = Camera.main.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Mathf.Abs(cursor.position.x - squares[0].position.x));
		for(int i = 0; i < 4; i++) {
			if(Mathf.Abs(cursor.position.x - squares[i].position.x) < 0.4*CamCon.SizeNow && Mathf.Abs(cursor.position.y - squares[i].position.y) < 0.4*CamCon.SizeNow) {
				if(Input.GetMouseButtonDown(0))	CamCon.SizeChange(i);
			}
		}
	}
}
