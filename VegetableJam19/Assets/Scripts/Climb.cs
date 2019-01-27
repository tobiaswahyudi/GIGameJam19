using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

	private CameraController CamCon;
	public Transform[] Segments;
	public GameObject Player;
	public Transform Cursor;

	public float hangOnDist;
	public float climbDist;
	public float clickDist;

	private Vector3 before;

	public SpriteRenderer pointingArrow;

	private int Height;
	private bool climbing;
	private int segs;

	// Use this for initialization
	void Start () {
		CamCon = Camera.main.GetComponent<CameraController>();
		Height = 0;
		segs = Segments.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (!climbing) {
			if(CamCon.Size == 0)
			if (Vector3.Distance(Player.transform.position, Segments[0].transform.position) < climbDist) {
				pointingArrow.enabled = true;
				if (Input.GetMouseButtonDown(0) && Mathf.Abs(Cursor.transform.position.x - Segments[0].transform.position.x) < clickDist) {
					Player.GetComponent<PlayerController>().freeze = true;
					climbing = true;
					before = Player.transform.position;
					Height = 0;
					Player.GetComponent<Rigidbody2D>().simulated = false;
				}
			} else {
					pointingArrow.enabled = false;
				}
		} else {
			pointingArrow.enabled = false;
			if (Height == -1) {
				Player.transform.position = before + new Vector3(0.0f,1.0f,0.0f);
				Player.GetComponent<PlayerController>().freeze = false;
				climbing = false;
				Player.GetComponent<Rigidbody2D>().simulated = true;
			} else if (Height == segs - 1) {
				Player.GetComponent<PlayerController>().freeze = false;
				Player.transform.position = Segments[Height].position;
				climbing = false;
				Player.GetComponent<Rigidbody2D>().simulated = true;
			} else {
				Player.transform.position = Segments[Height].position + new Vector3(hangOnDist, 0.0f, 0.0f);
				if (Input.GetKeyDown(KeyCode.W)) Height++;
				if (Input.GetKeyDown(KeyCode.S)) Height--;
			}
		}
	}
}
