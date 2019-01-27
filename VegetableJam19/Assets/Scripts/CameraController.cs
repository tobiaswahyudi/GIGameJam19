using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera cam;
	public Transform Cursor;
	public Transform Player;
	public PlayerController PC;
	public Transform UI;
	public Holding Inventory;
	public float CamSpeed;
	public float CamHeight;
	public float SizeChangeSpeed;
	public float SizeNow;
	public float[] Sizes;
	public int Size;
	private float sizeDest;
	private bool changing;

	//private float playerHeight = 2.3f;

	// Use this for initialization
	void Start () {
		Size = 0;
		SizeNow = 1;
		cam = Camera.main;
		changing = false;
		PC = Player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(this.transform.position,Player.transform.position + new Vector3(0 ,CamHeight, -10),
			CamSpeed*(Mathf.Abs(Vector3.Distance(this.transform.position, Player.transform.position))-8.0f));
		if (changing) {
			PC.facingLeft = false;
			if(Mathf.Abs(SizeNow - sizeDest) < 0.01) {
				cam.orthographicSize = sizeDest;
				UI.transform.localScale = new Vector3(sizeDest, sizeDest, 1.0f);
				Player.transform.localScale = new Vector3(2 * sizeDest, 2 * sizeDest, 1.0f);
				changing = false;
			}
			float df = sizeDest - SizeNow;
			SizeNow += df * SizeChangeSpeed;
			cam.orthographicSize = SizeNow*5;
			UI.transform.localScale = new Vector3(SizeNow, SizeNow, 1.0f);
			Player.transform.localScale = new Vector3(2 * SizeNow, 2 * SizeNow, 1.0f);
		}
	}

	public void SizeChange(int destination) {
		Size = destination;
		if (!changing) {
			sizeDest = Sizes[destination];
			changing = true;
		}
	}
}
