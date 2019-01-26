using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Collider2D MainCol,JumpCol;
	private Rigidbody2D RB;

	public float HzAccel;
	public float MaxSpeed, Slowdown, HzSpeed,JumpForce;
	public float JumpDelay;
	public float JumpElapsed;

	private int touching;

	// Use this for initialization
	void Start () {
		JumpElapsed = 0;
		touching = 0;
		MainCol = GetComponents<Collider2D>()[0];
		JumpCol = GetComponents<Collider2D>()[0];
		RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		JumpElapsed += Time.deltaTime;
		JumpElapsed = Mathf.Clamp(JumpElapsed, 0, 2);
		float hzin = Input.GetAxis("Horizontal");
		if (hzin == 0) HzSpeed *= Slowdown;
		HzSpeed += HzAccel * hzin;
		HzSpeed = Mathf.Clamp(HzSpeed, -MaxSpeed, MaxSpeed);
		this.transform.Translate(new Vector3(HzSpeed, 0.0f, 0.0f));
		if (touching > 0 && JumpElapsed > JumpDelay && Input.GetAxis("Jump") > 0.5) {
			RB.AddForce(new Vector2(0.0f, JumpForce));
			JumpElapsed = 0;
		}

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		touching++;
		Debug.Log(touching);
	}
	private void OnTriggerExit2D(Collider2D collision) {
		touching--;
		Debug.Log(touching);
	}
}
