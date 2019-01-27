using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPointer2 : MonoBehaviour {

	private CameraController CC;
	private Transform Player;

	private bool b;

	public Seppuku Katana;
	public SpriteRenderer SR;

	// Use this for initialization
	void Start () {
		b = false;
		SR = GetComponent<SpriteRenderer>();
		Katana = GetComponent<Seppuku>();
		CC = Camera.main.GetComponent<CameraController>();
		Player = CC.Player;
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.x >= -13) {
			b = true;
			Katana.enabled = true;
			SR.enabled = true;
		}
		if (b && CC.Size == 0) GameObject.Destroy(this.gameObject);
	}
}
